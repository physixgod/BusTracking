using BusTracking.Domain.ENTITIES;

namespace BusTracking.Application.Interfaces;

public interface IEmployeesRepository
{
    ICollection<Employees> GetAllEmployess();
    Employees AddEmployee(Employees emp);
    Task<Employees> UpdateEmployeeImageUrl(int rfid, string imageUrl);
    List<Employees> addEmployeesList(List<Employees> emps);
    List<TrackingEventDto> GetTrackingEventsForLastMonth(int rfid);
}