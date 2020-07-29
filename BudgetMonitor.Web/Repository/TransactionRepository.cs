using BudgetMonitor.Web.Models;
using BudgetMonitor.Web.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BudgetMonitor.Web.Repository
{
    public class TransactionRepository: Repository<Transaction>, ITransactionRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        public TransactionRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {

        }
    }
}
