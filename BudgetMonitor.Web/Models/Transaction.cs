using System;
using System.ComponentModel.DataAnnotations;

namespace BudgetMonitor.Web.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }
    }
}
