using BudgetMonitor.Business;
using BudgetMonitor.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BudgetMonitor.Api.Controllers
{
    /// <summary>
    /// Controller to manage the transaction.
    /// </summary>
    [Route("api/v{version:apiVersion}/Transaction")]
    [ApiVersion("2.0")]
    //[Route("api/[controller]")]
    [ApiController]
    //[ApiExplorerSettings(GroupName = "BudgetMonitorAPISpecTransaction")]
    public class TransactionV2Controller : ControllerBase
    {
        ITransaction Transaction;

        /// <summary>
        /// Constructor for transaction controller
        /// </summary>
        /// <param name="transaction"></param>
        public TransactionV2Controller(ITransaction transaction)
        {
            Transaction = transaction;
        }

        /// <summary>
        /// Get list of transactions.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<TransactionUpdateDTO>))]
        [ProducesResponseType(400)]
        public IActionResult Get()
        {
            try
            {
                var result = Transaction.Get().ToList().FirstOrDefault();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        
        
    }
}
