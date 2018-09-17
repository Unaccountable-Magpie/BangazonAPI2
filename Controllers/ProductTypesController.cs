﻿using System;
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
        public async Task<IActionResult> Put([FromRoute]int id,  ProductTypes ProductTypes)
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
                if (!PaymentTypesExists(id))
                {

                }
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}