using AutoMapper;
using BudgetMonitor.Entities;

namespace BudgetMonitor.Business
{
    public class BudgetMappings :Profile
    {
        public BudgetMappings()
        {
            CreateMap<UserEntity, UserDTO>().ReverseMap();
            CreateMap<TransactionEntity, TransactionUpdateDTO>().ReverseMap();
            //CreateMap<TransactionEntity, TransactionCreateDTO>().ReverseMap();

        }
    }
}
