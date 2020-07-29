using BudgetMonitor.Web.Models;
using System.Threading.Tasks;

namespace BudgetMonitor.Web.Repository
{
    public interface IAccountRepository
    {
        Task<AuthenticationTokenModel> LoginAsync(string url, AuthenticationModel authenticationModel);
        Task<bool> RegisterAsync(string url, User user);
    }
}