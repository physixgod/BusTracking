using AutoMapper;
using BusTracking.Domain.Dto;
using BusTracking.Domain.ENTITIES;

namespace BusTracking.Domain.Helpers;

public class Profiles:Profile
{
    public Profiles()
    {
        CreateMap<Employees,EmployeeDto>();
       
    }
    
}