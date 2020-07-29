using BudgetMonitor.Business;
using BudgetMonitor.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Net;

namespace BudgetMonitor.Api.Controllers
{
    /// <summary>
    /// User Controller.
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("api/v{version:apiVersion}/User")]
    //[ApiExplorerSettings(GroupName = "BudgetMonitorAPISpecUser")]
    public class UserController : ControllerBase
    {
        IUser user;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="user"></param>
        public UserController(IUser user)
        {
            this.user = user;
        }


        /// <summary>
        /// Method : Authenticate User
        /// </summary>
        /// <param name="authenticateDTO"></param>
        /// <returns>UserName and token.</returns>
        [Route("/User/AuthenticateUser")]
        [HttpPost("AuthenticateUser")]
        [SwaggerOperation("AuthenticateUser")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthenticateTokenDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [AllowAnonymous]
        public IActionResult AuthenticateUser(AuthenticateDTO authenticateDTO)
        {
            try
            {
                var result = user.AuthenticateUser(authenticateDTO);
                if (result == null)
                    return BadRequest("Login or password is incorrect");
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
        [Route("/User/RegisterUser")]
        [HttpPost("RegisterUser")]
        [SwaggerOperation("RegisterUser")]
        [AllowAnonymous]
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

        ///// <summary>
        ///// Method : Modify User
        ///// </summary>
        ///// <param name="userDTO"></param>
        ///// <returns>UserName and token.</returns>
        //[Route("/User/ModifyUser")]
        //[HttpPatch("ModifyUser")]
        //public IActionResult ModifyUser(UserDTO userDTO)
        //{
        //    try
        //    {
        //        var result = user.ModifyUser(userDTO);
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return NotFound(ex.Message);
        //    }

        //}

        /// <summary>
        /// Method : Change Password
        /// </summary>
        /// <param name="changePasswordDTO"></param>
        /// <returns>UserName and token.</returns>
        [Route("/User/ChangePassword")]
        [HttpPatch("ChangePassword")]
        [SwaggerOperation("ChangePassword")]

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
