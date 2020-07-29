﻿using BudgetMonitor.Web.Models;
using BudgetMonitor.Web.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BudgetMonitor.Web.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        public UserRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {

        }

        public bool AuthenticateUser(string userName, string secret)
        {
            throw new NotImplementedException();
        }
    }
}
