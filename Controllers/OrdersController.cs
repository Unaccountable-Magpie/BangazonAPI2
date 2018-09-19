//Author: Austin Gorman
//Purpose: To get, post, put and delete items from the orders table
//Methods:
//Get: Gets all orders 
//Get One: Gets one order
//Post: Adds new order
//Put: Edits existing order
//Delete: Removes an order and also removes the ProductOrder joint table entry with a corresponding OrderID foreign key


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

        // GET api/orders?completed=false
        [HttpGet]
        public async Task<IActionResult> Get(string completed)
        {
            using (IDbConnection conn = Connection)
            {
                string sql = "SELECT * FROM Orders";

                if (completed != null && completed.Contains("true"))
                {
                    sql += $" WHERE [Orders].PaymentTypesId IS NOT NULL";
                }
                if (completed != null && completed.Contains("false"))
                {
                    sql += $" WHERE [Orders].PaymentTypesId IS NULL";
                }  

                var OrdersCompleted = await conn.QueryAsync<Orders>(sql);
                return Ok(OrdersCompleted);

            }

        }

        // GET ONE: api/Orders/5
        [HttpGet("{id}", Name = "GetOrders")]
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
            (CustomersId, PaymentTypesId)
            VALUES
            ('{orders.CustomersId}',  '{orders.PaymentTypesId}');
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
            UPDATE Orders
            SET CustomersId = {orders.CustomersId},
                PaymentTypesId = {orders.PaymentTypesId}
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
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            string sql = $@"DELETE FROM ProductOrders WHERE OrdersId = {id} ;
                            DELETE FROM Orders WHERE Id = {id}";

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

        private bool OrdersExists(int id)
        {
            string sql = $"SELECT CustomersId, PaymentTypesId FROM Orders WHERE Id = {id}";
            using (IDbConnection conn = Connection)
            {
                return conn.Query<Orders>(sql).Count() > 0;
            }
        }
    }
}
