using System.Collections.Generic;
using System.Threading.Tasks;

namespace BudgetMonitor.Business
{
    public interface IBaseBusiness<TEntity> where TEntity : class
    {
        Task<bool> Add(TEntity entity);

        bool Update(TEntity entity);

        bool Delete(int Id);
        Task<TEntity> Get(int Id);

        IEnumerable<TEntity> Get();

    }
}
