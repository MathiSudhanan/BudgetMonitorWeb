using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetMonitor.Web.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "User Name is required.")]
        [StringLength(maximumLength: 30, ErrorMessage = "Name should not be more than 100 characters.")]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required.")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [NotMapped]
        public string ConfirmPassword { get; set; }

        public string EmailId { get; set; }

        public byte[] Picture { get; set; }
    }
}
