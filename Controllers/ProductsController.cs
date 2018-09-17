using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BangazonAPI.Models
{
    [Route("api[controller]")]
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
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
