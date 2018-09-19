//Author - Jewel Ramirez
//Purpose - Reflects the PaymentType table in the database and its values. 
//Has all the calls for getting information, adding information, updating, and deleted

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
    public class PaymentTypesController : ControllerBase
    {
        private readonly IConfiguration _config;
   

        public PaymentTypesController(IConfiguration config)
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
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            using (IDbConnection conn = Connection)
            {
                string sql = "SELECT * FROM PaymentTypes";

                var fullPayments = await conn.QueryAsync<PaymentTypes>(sql);
                return Ok(fullPayments);
            }

        }

        // GET: api/PaymentTypes/5
        
         [HttpGet("{id}", Name = "GetPaymentTypes")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            using (IDbConnection conn = Connection)
            {
                string sql = $"SELECT * FROM PaymentTypes WHERE Id = {id}";

                var theSinglePayment = (await conn.QueryAsync<PaymentTypes>(sql)).Single();
                return Ok(theSinglePayment);
            }
        }

        // POST: api/PaymentTypes
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PaymentTypes PaymentTypes)
        {
            string sql = $@"INSERT INTO PaymentTypes
            (Name, AccountNumber, CustomersId, IsDeleted)
            VALUES
            ('{PaymentTypes.Name}','{PaymentTypes.AccountNumber}','{PaymentTypes.CustomersId}','{PaymentTypes.IsDeleted}');
            select MAX(Id) from PaymentTypes";

            using (IDbConnection conn = Connection)
            {
                var newPaymentTypesId = (await conn.QueryAsync<int>(sql)).Single();
                PaymentTypes.Id = newPaymentTypesId;
                return CreatedAtRoute("GetPaymentTypes", new { id = newPaymentTypesId }, PaymentTypes);
            }

        }

        // PUT: api/PaymentTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] PaymentTypes paymentTypes)
        {
            string sql = $@"
            UPDATE PaymentTypes
            SET 
                Name = '{paymentTypes.Name}',
                AccountNumber = '{paymentTypes.AccountNumber}',
                CustomersId = '{paymentTypes.CustomersId}',
               IsDeleted = '{paymentTypes.IsDeleted}'
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
            string sql = $@"DELETE FROM PaymentTypes WHERE Id = {id}";

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

        private bool PaymentTypesExists(int id)
        {
            string sql = $"SELECT CustomerId, Name, AccountNumber FROM PaymentTypes WHERE Id = {id}";
            using (IDbConnection conn = Connection)
            {
                return conn.Query<PaymentTypes>(sql).Count() > 0;
            }
        }
    }
}
