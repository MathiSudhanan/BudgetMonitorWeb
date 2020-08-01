using AutoMapper;
using BudgetMonitor.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BudgetMonitor.Business
{
    public class Transaction : BaseBusiness, ITransaction
    {
        private IMapper Mapper;
        private readonly IHttpContextAccessor HttpContextAccessor;
        public Transaction(IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            Mapper = mapper;
            HttpContextAccessor = httpContextAccessor;
        }
        public async Task<bool> Add(TransactionUpdateDTO entity)
        {
            var transactionEntity = Mapper.Map<TransactionEntity>(entity);
            transactionEntity.UserId = Convert.ToInt32(HttpContextAccessor.HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
            var context = HttpContextAccessor.HttpContext;
            await UnitOfWork.TransactionRepository.Insert(transactionEntity);
            return UnitOfWork.Save() > 0;
        }

        public bool Delete(int Id)
        {
            if (Id == default)
                throw new Exception("No user is selected to delete.");

            UnitOfWork.TransactionRepository.Delete(Id);
            return UnitOfWork.Save() > 0;
        }

        public async Task<TransactionUpdateDTO> Get(int Id)
        {
            if (Id == default)
                throw new Exception("No user is selected.");
            var res = await UnitOfWork.TransactionRepository.GetByID(Id);
            return Mapper.Map<TransactionUpdateDTO>(res);
        }

        public IEnumerable<TransactionUpdateDTO> Get()
        {
            return UnitOfWork.TransactionRepository.Get().Select(x => Mapper.Map<TransactionUpdateDTO>(x));
        }

        public bool Update(TransactionUpdateDTO entity)
        {
            var transactionEntity = Mapper.Map<TransactionEntity>(entity);
            transactionEntity.UserId = Convert.ToInt32(HttpContextAccessor.HttpContext.User.Claims.First(x => x.Type == ClaimTypes.Name).Value);
            UnitOfWork.TransactionRepository.Update(transactionEntity);
            return UnitOfWork.Save() > 0;
        }
    }
}
