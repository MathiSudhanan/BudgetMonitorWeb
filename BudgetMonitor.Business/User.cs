using AutoMapper;
using BudgetMonitor.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BudgetMonitor.Business
{
    public class User : BaseBusiness, IUser
    {
        private IMapper Mapper;
        private readonly AppSettings appSettings;

        public User(IMapper mapper, IOptions<AppSettings> options)
        {
            Mapper = mapper;
            appSettings = options.Value;
        }

        public AuthenticateTokenDTO AuthenticateUser(AuthenticateDTO authenticateDTO)
        {
            if (string.IsNullOrWhiteSpace(authenticateDTO.EmailId) || string.IsNullOrWhiteSpace(authenticateDTO.Password))
                throw new Exception("Invalid user name or password.");
            var result = UnitOfWork.UserRepository.AuthenticateUser(authenticateDTO.EmailId, authenticateDTO.Password);
            if (result == null)
                return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim(ClaimTypes.Name, result.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            AuthenticateTokenDTO authenticateTokenDTO = new AuthenticateTokenDTO
            {
                UserName = result.FirstName + " " + result.LastName,
                Token = tokenHandler.WriteToken(token)
            };

            return authenticateTokenDTO;
        }

        public bool ChangePassword(ChangePasswordDTO changePasswordDTO)
        {
            UnitOfWork.UserRepository.ChangePassword(changePasswordDTO.UserId, changePasswordDTO.NewPassword);
            return UnitOfWork.Save() > 0;
        }

        public bool IsEmailUnique(string emailId)
        {
            return UnitOfWork.UserRepository.IsEmailUnique(emailId);
        }

        public bool ModifyUser(UserDTO user)
        {
            var userEntity = Mapper.Map<UserEntity>(user);
            UnitOfWork.UserRepository.ModifyUser(userEntity);
            return UnitOfWork.Save() > 0;
        }

        public bool RegisterUser(UserDTO user)
        {
            var userEntity = Mapper.Map<UserEntity>(user);
            UnitOfWork.UserRepository.RegisterUser(userEntity);
            return UnitOfWork.Save() > 0;
        }
       
    }
}
