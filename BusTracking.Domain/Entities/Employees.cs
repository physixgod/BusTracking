using System.ComponentModel.DataAnnotations;

namespace BusTracking.Domain.ENTITIES;

public class Employees
{
    [Key]
    public int Matricule { get; set; }
    public int Rfid { get; set; }
    public string EmployeeFirstName { get; set; }
    public string EmployeeLastName { get; set; }
    public string Adresse { get; set; }
    public string Region { get; set; }
    public string Gouvernement { get; set; }
    public bool pointed { get; set; }
}