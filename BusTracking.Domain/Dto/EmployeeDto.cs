namespace BusTracking.Domain.Dto;

public class EmployeeDto
{
    public string Matricule { get; set; }
    public int Rfid { get; set; }
    public string EmployeeFirstName { get; set; }
    public string EmployeeLastName { get; set; }
    public string Adresse { get; set; }
    public string Region { get; set; }
    public string Gouvernement { get; set; }
}