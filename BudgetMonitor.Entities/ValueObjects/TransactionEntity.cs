using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetMonitor.Entities
{
    public class TransactionEntity : BaseVOEntity
    {
        public string Name { get; set; }
        public Decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }


        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public UserEntity User { get; set; }
    }
}
