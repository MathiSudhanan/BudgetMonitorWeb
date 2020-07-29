using BudgetMonitor.Business;
using BudgetMonitor.Entities;
using Microsoft.AspNetCore.Authorization;
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
    /// 
    //[Route("api/[controller]")]
    [ApiController]
    [Authorize]
    //[ApiExplorerSettings(GroupName = "BudgetMonitorAPISpecTransaction")]
    public class TransactionController : ControllerBase
    {
        ITransaction Transaction;

        /// <summary>
        /// Constructor for transaction controller
        /// </summary>
        /// <param name="transaction"></param>
        public TransactionController(ITransaction transaction)
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
                var result = Transaction.Get().ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Get individual transaction.
        /// </summary>
        /// <param name="id"> The id of the transaction. </param>
        /// <returns></returns>
        [HttpGet("{id:int}" , Name = "GetTransaction")]
        [ProducesResponseType(200, Type = typeof(TransactionUpdateDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<TransactionUpdateDTO>> GetTransaction(int id)
        {
            var result = await Transaction.Get(id);
            if (result == default)
                return NotFound();
            return Ok(result);
        }


        /// <summary>
        /// Create a transaction.
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(TransactionUpdateDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesDefaultResponseType]

        public async Task<ActionResult> Post(TransactionUpdateDTO transaction)
        {
            if (transaction == default)
                return BadRequest(ModelState);
            var result = await Transaction.Add(transaction);
            if (!result)
            {
                ModelState.AddModelError("", $"Something went wrong while saving the record {transaction.Name}.");
                return StatusCode(500, ModelState);
            }
            var vers = HttpContext.GetRequestedApiVersion().ToString();
            return CreatedAtRoute("GetTransaction", new { version = HttpContext.GetRequestedApiVersion().ToString(), id = transaction.Id }, transaction);
        }

        /// <summary>
        /// Update the transaction
        /// </summary>
        /// <param name="transactionId">Id of the transaction.</param>
        /// <param name="transaction">Transaction object instance.</param>
        /// <returns></returns>
        [HttpPatch("{transactionId:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public IActionResult Patch(int transactionId, TransactionUpdateDTO transaction)
        {
            if (transaction == default || transactionId != transaction.Id)
                return BadRequest(ModelState);
            var result = Transaction.Update(transaction);
            if (!result)
            {
                ModelState.AddModelError("", $"Something went wrong while updating the record {transaction.Name}.");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }

        /// <summary>
        /// Delete the transaction.
        /// </summary>
        /// <param name="id">id of the transaction.</param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public IActionResult Delete(int id)
        {
            var result = Transaction.Delete(id);
            if (!result)
            {
                ModelState.AddModelError("", $"Something went wrong while updating the record id {id}.");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
