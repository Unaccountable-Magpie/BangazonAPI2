/*Purpose: Allows user to Get information stored inside the ProductTypes table,
        Allows user to Post new information to the table with a new ProductTypes Id,
        Allows user to Put or update a ProductTypes Name by the associated Id,
        Allows user to Delete a ProductTypes Name by the associated Id from the ProductTypes table*/
//Author: Amanda Mitchell
//Models: ProductTypes

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
    public class ProductTypesController : ControllerBase
    {
        private readonly IConfiguration _config;

        public ProductTypesController(IConfiguration config)
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
        // GET: api/ProductTypes
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            using (IDbConnection conn = Connection)
            {
                string sql = $@"SELECT * FROM ProductTypes";

                var ProductTypesQuery = await conn.QueryAsync<ProductTypes>(sql);
                return Ok(ProductTypesQuery);
            }
        }

        // GET: api/ProductTypes/3
        [HttpGet("{id}", Name = "GetProductTypes")]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            using (IDbConnection conn = Connection)
            {
                string sql = $"SELECT * FROM ProductTypes WHERE Id = {id}";

                var SingleProductType = (await conn.QueryAsync<ProductTypes>(sql)).Single();
                return Ok(SingleProductType);
            }
        }

        // POST: api/ProductTypes
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductTypes ProductTypes)
        {
            string sql = $@"INSERT INTO ProductTypes
                (Name)
                VALUES
                ('{ProductTypes.Name}');
                select MAX(Id) from ProductTypes";

            using (IDbConnection conn = Connection)
            {
                var NewProductTypesId = (await conn.QueryAsync<int>(sql)).Single();
                ProductTypes.Id = NewProductTypesId;
                return CreatedAtRoute("GetProductTypes", new { id = NewProductTypesId }, ProductTypes);
            }
        }

        // PUT: api/ProductTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute]int id,  [FromBody]ProductTypes ProductTypes)
        {
            string sql = $@"
            UPDATE ProductTypes
            SET Name = '{ProductTypes.Name}'
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
                if (!ProductTypesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            string sql = $@"DELETE From ProductTypes WHERE Id = {id}";

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
                if (ProductsExists(id))
                {
                    return new StatusCodeResult(StatusCodes.Status405MethodNotAllowed);
                }
                else
                {
                    throw;
                }
            }
        }

        private bool ProductTypesExists(int id)
        {
            string sql = $"SELECT Id, Name FROM ProductTypes WHERE Id = {id}";
            using (IDbConnection conn = Connection)
            {
                return conn.Query<ProductTypes>(sql).Count() > 0;
            }
        }

        private bool ProductsExists(int id)
        {
            string sql = $"SELECT * FROM Products p WHERE p.ProductTypesId = {id}";
            using (IDbConnection conn = Connection)
            {
                return conn.Query<Products>(sql).Count() > 0;
            }
        }
    }
}

