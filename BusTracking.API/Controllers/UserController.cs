using BusTracking.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BusTracking.API.Controllers;
[Route("bustracking/[controller]")]
[ApiController]
public class UserController:ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet("getUsers")]
    public IActionResult GetUsers()
    {
        Console.WriteLine(_userRepository.getUsers().Count);
        return Ok(_userRepository.getUsers());
    }

}