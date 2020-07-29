using System;
using System.ComponentModel.DataAnnotations;

namespace BudgetMonitor.Entities
{
    public class TransactionCreateDTO 
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }
    }
}
