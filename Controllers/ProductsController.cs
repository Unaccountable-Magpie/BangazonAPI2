//Author: Lauren Richert
//Purpose: Get, post, put and delete things from the products table
//Methods:
//Get: Gets all products 
//Get One: Gets a single product
//Post: Adds a new product
//Put: Edits an existing product
//Delete: Deletes a product and also deletes the entry in the ProductOrder joint with a corresponding ProductId foreign key



using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BangazonAPI.Models;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BangazonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IConfiguration _config;

        public ProductsController(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }


        // GET: api/Products
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            using (IDbConnection conn = Connection)
            {
                string sql = "SELECT * FROM Products";

                var ProductsQuery = await conn.QueryAsync<Products>(sql);
                return Ok(ProductsQuery);
            }
        }



        // GET: api/Products/5
        [HttpGet("{id}", Name = "GetProducts")]
        public async Task<IActionResult> Get([FromRoute]int id)
        {

            using (IDbConnection conn = Connection)

            {
                string sql = $"SELECT * FROM Products WHERE Id = {id}";
                var singleProducts = (await conn.QueryAsync<Products>(sql)).Single();
                return Ok(singleProducts);
            }
        }


        // POST: api/Products
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Products Products)
        {
            string sql = $@"INSERT INTO Products
            ( Price, Title, Description, Quantity, CustomersId, ProductTypesId)
            VALUES
            ( `{Products.CustomersId}`, {Products.ProductTypesId}){Products.Price}`, {Products.Title}`, {Products.Description}`, {Products.Quantity}`); 
            SELECT MAX(Id) from Products";

            using (IDbConnection conn = Connection)
            {
                var newProductsId = (await conn.QueryAsync<int>(sql)).Single();
                Products.Id = newProductsId;
                return CreatedAtRoute("GetProducts", new { id = newProductsId }, Products);
            }
        }


        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] Products Products)
        {
            string sql = $@"
            UPDATE Products
            SET
                CustomersId = {Products.CustomersId},
                ProductTypesId = {Products.ProductTypesId}
                Price = {Products.Price}
                Title = {Products.Title}
                Description = {Products.Description}
                Quantity - {Products.Quantity}
            WHERE Id = {id}";

            try
            {
                using (IDbConnection conn = Connection)
                {
                    int rowsAffected = await conn.ExecuteAsync(sql);
                    if (rowsAffected > 0)
                    {
                        return new StatusCodeResult(StatusCodes.Status204NoContent);
                    }
                    throw new Exception("No rows affected");
                }
            }
            catch (Exception)
            {
                if (!ProductsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        private bool CustomerExists(int id)
        {
            string sql = $"SELECT Id, Name, Language FROM Customer WHERE Id = {id}";
            using (IDbConnection conn = Connection)
            {
                return conn.Query<Customers>(sql).Count() > 0;
            }
        }



        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            string sql = $@"DELETE FROM Products WHERE Id = {id}";

            using (IDbConnection conn = Connection)
            {
                int rowsAffected = await conn.ExecuteAsync(sql);
                if (rowsAffected > 0)
                {
                    return new StatusCodeResult(StatusCodes.Status204NoContent);
                }
                throw new Exception("No rows affected");
            }

        }

        private bool ProductsExists(int id)
        {
            string sql = $"SELECT CustomersId, ProductTypesId, Price, Title, Description, Quantity FROM Products WHERE Id = {id}";
            using (IDbConnection conn = Connection)

            {
                return conn.Query<Products>(sql).Count() > 0;
            }
        }
    }
}


