using System;
using System.ComponentModel.DataAnnotations;


namespace BudgetMonitor.Entities
{
    public class UserEntity : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public byte[]? Picture { get; set; }
    }
}
