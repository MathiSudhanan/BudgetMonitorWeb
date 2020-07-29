using System;
using System.ComponentModel.DataAnnotations;

namespace BudgetMonitor.Entities
{
    public class BaseVOEntity : BaseEntity
    {
        
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
