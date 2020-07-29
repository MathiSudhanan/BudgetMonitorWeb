using BudgetMonitor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetMonitor.DAL
{
    public class TransactionRepository : GenericRepository<TransactionEntity>, ITransactionRepository
    {
        public TransactionRepository(BudgetMonitorContext context) : base(context)
        {

        }
    }
}
