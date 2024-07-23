using BusTracking.Domain.ENTITIES;

namespace BusTracking.Application.Interfaces;

public interface IEmployeesRepository
{
    ICollection<Employees> getEmployees();
}