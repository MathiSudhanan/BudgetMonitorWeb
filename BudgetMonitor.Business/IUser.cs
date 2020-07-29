using BudgetMonitor.Entities;

namespace BudgetMonitor.Business
{
    public interface IUser 
    {
        AuthenticateTokenDTO AuthenticateUser(AuthenticateDTO authenticateDTO);

        bool IsEmailUnique(string emailId);

        bool RegisterUser(UserDTO user);

        bool ChangePassword(ChangePasswordDTO changePasswordDTO);

        bool ModifyUser(UserDTO user);
    }
}
