using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetMonitor.Web.Repository.IRepository
{
    public interface IRepository<T> where T:class
    {
        Task<T> GetAsync(string url, string token, int id);
        Task<IEnumerable<T>> GetAllAsync(string url, string token);

        Task<bool> CreateAsync(string url, string token, T objectToCreate);
        Task<bool> UpdateAsync(string url, string token, T objectToUpdate);

        Task<bool> DeleteAsync(string url, string token, int id);
    }
}
