using System;
using System.ComponentModel.DataAnnotations;

namespace BudgetMonitor.Entities
{
    public class UserDTO : BaseEntity
    {
        
        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(maximumLength: 100, ErrorMessage = "First Name should not be more than 100 characters.")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "EmailId is required.")]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }
        
        public byte[]? Picture { get; set; }

    }
}
