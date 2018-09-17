using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BangazonAPI.Models;

namespace BangazonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IConfiguration _config;

        public OrdersController(IConfiguration config)
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

        // GET: api/Orders
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            using (IDbConnection conn = Connection)
            {
                string sql = $"SELECT * FROM Orders";

                var AllOrders = (await conn.QueryAsync<Orders>(sql));
                return Ok(AllOrders);
            }
        }

        // GET: api/Orders/5
        [HttpGet("{id}", Name = "GetExercise")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            using (IDbConnection conn = Connection)
            {
                string sql = $"SELECT * FROM Orders WHERE Id = {id}";

                var theSingleOrder = (await conn.QueryAsync<Orders>(sql)).Single();
                return Ok(theSingleOrder);
            }
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Orders orders)
        {
            string sql = $@"INSERT INTO Orders
            (CustomersId, Customers, PaymentTypesId, PaymentTypes)
            VALUES
            ('{orders.CustomersId}', '{orders.Customers}', '{orders.PaymentTypesId}', '{orders.PaymentTypes}');
            select MAX(Id) from Orders";

            using (IDbConnection conn = Connection)
            {
                var newOrdersId = (await conn.QueryAsync<int>(sql)).Single();
                orders.Id = newOrdersId;
                return CreatedAtRoute("GetOrders", new { id = newOrdersId }, orders);
            }

        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] Orders orders)
        {
            string sql = $@"
            UPDATE Exercise
            SET Customers = '{orders.Customers}',
                PaymentTypes = '{orders.PaymentTypes}'
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
                if (!OrdersExists(id))
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
        public void Delete(int id)
        {
        }
    }
}
