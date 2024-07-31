using System.Security.Cryptography;
using BusTracking.Application.Interfaces;
using BusTracking.Domain.Dto;
using BusTracking.Domain.ENTITIES;
using BusTracking.Infrastructure.DATA;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using MimeKit.Text;

namespace BusTracking.Application.Repositories;

public class UserRepository:IUserRepository
{
    private readonly DataContext _context;
    public UserRepository(DataContext context)
    {
        this._context = context;
    }


    public ICollection<User> getUsers()
    {
        return _context.Users.OrderBy(p=>p.Login).ToList();
    }

    public bool EmailExists(string email)
    {
        return _context.Users.Any(u => u.Email == email);
    }

    public async Task<User?> GetUserAsync(LoginRequest userRequest)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Login == userRequest.Login && u.Password == userRequest.Password);
        return user;
    }

    public User Register(User userRequest)
    {
        var newUser = new User
        {

            Login= userRequest.Login,
            Email = userRequest.Email,
            Password = userRequest.Password,
            Societe = userRequest.Societe,

        };
        _context.Users.Add(newUser);
        _context.SaveChanges();
        return newUser;
    }

    public string Forgetpassword(string Email)
    {
        var user = _context.Users.SingleOrDefault(u => u.Email == Email);
        if (user == null)
        {
            throw new ArgumentException("No user found with the provided email.");
        }
        string resetCode = GenerateResetCode();
        user.CodeP = resetCode; 
        _context.SaveChanges(); 
        SendResetCodeEmail(Email, resetCode);
        return resetCode;
    }
    private string GenerateResetCode()
    {
        using (var rng = new RNGCryptoServiceProvider())
        {
            byte[] data = new byte[8];
            rng.GetBytes(data);
            return BitConverter.ToString(data).Replace("-", "");
        }
    }
    private void SendResetCodeEmail(string toEmail, string resetCode)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse("necroyasuo17@gmail.com"));
        email.To.Add(MailboxAddress.Parse(toEmail));
        email.Subject = "Password Reset Code";
        email.Body = new TextPart(TextFormat.Html) 
        { 
            Text = $"<p>Your password reset code is: <strong>{resetCode}</strong></p>"
        };

        using var smtp = new SmtpClient();
        smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
        smtp.Authenticate("necroyasuo17@gmail.com", "rxur cmjf knva flpd");
        smtp.Send(email);
        smtp.Disconnect(true);
    }
    public bool VerifyResetCodeAndUpdatePassword(string resetCode, string newPassword)
    {
        var user = _context.Users.SingleOrDefault(u => u.CodeP == resetCode);
        if (user == null)
        {
            throw new ArgumentException("Invalid reset code.");
        }
        user.Password = newPassword;
        user.CodeP = null;
        _context.SaveChanges();
        return true;
    }
}