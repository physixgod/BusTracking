using System;
using System.Threading.Tasks;
using BusTracking.Application.Interfaces;
using BusTracking.Domain.Dto;
using BusTracking.Domain.ENTITIES;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BusTracking.API.Controllers
{
    [Route("bustracking/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserRepository userRepository, ILogger<UserController> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        [HttpGet("getUsers")]
        public IActionResult GetUsers()
        {
            Console.WriteLine(_userRepository.getUsers().Count);
            return Ok(_userRepository.getUsers());
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest userRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userRepository.GetUserAsync(userRequest);

            if (user == null)
            {
                return Unauthorized("Invalid Username or password.");
            }

            return Ok(user);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(User userRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Bad Request.");
            }

            if (_userRepository.EmailExists(userRequest.Email))
            {
                return BadRequest("Email already registered.");
            }

            _userRepository.Register(userRequest);
            return Ok(new
            {
                User = userRequest,
                Message = "User registered successfully."
            });
        }

        [HttpPost("ForgetPassword")]
        public IActionResult ForgetPassword([FromBody] ForgetPasswordRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                string resetCode = _userRepository.Forgetpassword(request.Email);
                return Ok(new
                {
                    Message = "Password reset code sent to email.",
                    ResetCode = resetCode 
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while processing forget password request.");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPost("ResetPassword")]
        public IActionResult ResetPassword([FromBody] ResetPasswordRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                bool success = _userRepository.VerifyResetCodeAndUpdatePassword(request.ResetCode, request.NewPassword);
                if (success)
                {
                    return Ok(new { Message = "Password reset successfully." });
                }
                else
                {
                    return BadRequest("Invalid reset code.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while processing reset password request.");
                return StatusCode(500, "Internal server error.");
            }
        }
    }

    public class ForgetPasswordRequest
    {
        public string Email { get; set; }
    }

    public class ResetPasswordRequest
    {
        public string ResetCode { get; set; }
        public string NewPassword { get; set; }
    }
}
