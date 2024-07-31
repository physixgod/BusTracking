using BusTracking.Domain.Dto;
using BusTracking.Domain.ENTITIES;

namespace BusTracking.Application.Interfaces;

public interface IUserRepository
{
    ICollection<User> getUsers();
    public bool EmailExists(string email);
    public Task<User?> GetUserAsync(LoginRequest userRequest);
    public User Register(User userRequest);
    public string Forgetpassword(string Email);
    public bool VerifyResetCodeAndUpdatePassword(string resetCode, string newPassword);

}