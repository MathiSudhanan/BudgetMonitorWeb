using BudgetMonitor.Business;
using BudgetMonitor.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;
using System;

namespace BudgetMonitor.Api.Controllers
{
    /// <summary>
    /// Account Controller
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/Account")]
    [Authorize]
    public class AccountController : ControllerBase
    {
        IUser user;
        /// <summary>
        /// constructor 
        /// </summary>
        /// <param name="user"></param>
        public AccountController(IUser user)
        {
            this.user = user;
        }

        /// <summary>
        /// Method : Authenticate User
        /// </summary>
        /// <param name="authenticateDTO"></param>
        /// <returns>UserName and token.</returns>
        [SwaggerOperation("AuthenticateUser")]
        [AllowAnonymous]
        [HttpPost("AuthenticateUser")]
        public IActionResult AuthenticateUser(AuthenticateDTO authenticateDTO)
        {
            try
            {
                var result = user.AuthenticateUser(authenticateDTO);
                if (result == null)
                    return BadRequest("User login or password is incorrect.");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        /// <summary>
        /// Method : Register User
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns>UserName and token.</returns>
        [AllowAnonymous]
        [HttpPost]
        public IActionResult RegisterUser(UserDTO userDTO)
        {
            try
            {
                var result = user.RegisterUser(userDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        /// <summary>
        /// Method : Modify User
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns>UserName and token.</returns>
        [Route("/User/ModifyUser")]
        [HttpPatch]
        public IActionResult ModifyUser(UserDTO userDTO)
        {
            try
            {
                var result = user.ModifyUser(userDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        /// <summary>
        /// Method : Change Password
        /// </summary>
        /// <param name="changePasswordDTO"></param>
        /// <returns>UserName and token.</returns>
        [SwaggerOperation("ChangePassword")]
        [HttpPatch("ChangePassword")]
        public IActionResult ChangePassword(ChangePasswordDTO changePasswordDTO)
        {
            try
            {
                var result = user.ChangePassword(changePasswordDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
    }
}
