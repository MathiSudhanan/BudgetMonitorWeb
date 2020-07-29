using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetMonitor.Entities
{
    public class TransactionUpdateDTO : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }
        
    }
}
