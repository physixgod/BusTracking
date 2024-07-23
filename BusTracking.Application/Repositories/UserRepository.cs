using BusTracking.Application.Interfaces;
using BusTracking.Domain.ENTITIES;
using BusTracking.Infrastructure.DATA;

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
}