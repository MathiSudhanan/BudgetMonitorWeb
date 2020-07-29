using BudgetMonitor.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetMonitor.DAL
{
    public class BudgetMonitorContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public DbSet<TransactionEntity> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=password-1;Database=BudMonitor;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().ToTable("Users");
            modelBuilder.Entity<TransactionEntity>().ToTable("Transactions");
        }


    }
}
