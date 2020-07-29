using System.ComponentModel.DataAnnotations;

namespace BudgetMonitor.Web.Models
{
    public class AuthenticationModel
    {
        [Required]
        public string EmailId { get; set; }

        [Required]  
        public string Password { get; set; }
    }
}
