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
                string sql = "SELECT * FROM ProductTypes";

                var ProductTypesQuery = await conn.QueryAsync<ProductTypes>(sql);
                return Ok(ProductTypesQuery);
            }
        }

        // GET: api/ProductTypes/3
        [HttpGet("{id}", Name = "Get")]
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
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/ProductTypes/5
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
