using BudgetMonitor.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetMonitor.Web.Repository.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        bool AuthenticateUser(string userName, string secret);
    }
}
