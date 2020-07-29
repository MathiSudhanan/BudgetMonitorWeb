using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetMonitor.Web.Models
{
    public class ChangePasswordModel
    {

        public int UserId { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        [NotMapped]
        public string ConfirmPassword { get; set; }
    }
}
