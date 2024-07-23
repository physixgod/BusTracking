using BusTracking.Domain.ENTITIES;

namespace BusTracking.Application.Interfaces;

public interface IUserRepository
{
    ICollection<User> getUsers();

}