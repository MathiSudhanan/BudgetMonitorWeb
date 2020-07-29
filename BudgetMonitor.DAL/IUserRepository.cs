using BudgetMonitor.Entities;

namespace BudgetMonitor.DAL
{
    public interface IUserRepository 
    {
        UserEntity AuthenticateUser(string emailId, string password);

        bool IsEmailUnique(string emailId);

        void RegisterUser(UserEntity user);

        void ChangePassword(int userId, string newPassword);

        void ModifyUser(UserEntity user);
    }
}
