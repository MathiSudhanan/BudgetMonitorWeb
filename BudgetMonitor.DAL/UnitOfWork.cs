using BudgetMonitor.Entities;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetMonitor.DAL
{
    public class UnitOfWork: IDisposable 
    {
        private BudgetMonitorContext context = new BudgetMonitorContext();
        private UserRepository userRepository;
        private TransactionRepository transactionRepository;

        public UserRepository UserRepository
        {
            get
            {

                if (this.userRepository == null)
                {
                    this.userRepository = new UserRepository(context);
                }
                return userRepository;
            }
        }
        public TransactionRepository TransactionRepository
        {
            get
            {

                if (this.transactionRepository == null)
                {
                    this.transactionRepository = new TransactionRepository(context);
                }
                return transactionRepository;
            }
        }


        public int Save()
        {
            return context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
