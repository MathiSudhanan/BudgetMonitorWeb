using BudgetMonitor.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BudgetMonitor.DAL
{
    public class UserRepository :  IUserRepository
    {
        public BudgetMonitorContext Context { get; set; }
        public UserRepository(BudgetMonitorContext context) 
        {
            Context = context;
        }

        public UserEntity AuthenticateUser(string emailId, string password)
        {
            return Context.Users.FirstOrDefault(x => x.EmailId.ToLower().Trim() == emailId.ToLower().Trim() && x.Password == password);
        }

        public bool IsEmailUnique(string emailId)
        {
            return !Context.Users.Any(x => x.EmailId.ToLower() == emailId.ToLower());
        }

        public async void RegisterUser(UserEntity user)
        {
            await Context.Users.AddAsync(user);
        }

        public void ChangePassword(int userId, string newPassword)
        {
            var user = Context.Users.First(x => x.Id == userId);
            user.Password = newPassword;
            Context.Attach(user);
            Context.Entry(user).State = EntityState.Modified;
        }

        public void ModifyUser(UserEntity user)
        {
            var userEntity = Context.Users.First(x => x.Id == user.Id);
            userEntity.FirstName = user.FirstName;
            userEntity.LastName = user.LastName;
            userEntity.EmailId = user.EmailId;
            if (user.Picture != null)
                userEntity.Picture = userEntity.Picture;
            Context.Attach(user);
            Context.Entry(user).State = EntityState.Modified;
        }
    }
}
