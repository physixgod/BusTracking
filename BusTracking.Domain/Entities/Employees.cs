using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusTracking.Domain.ENTITIES
{
    public class Employees
    {
        
        public string Matricule { get; set; }
        [Key]
        public int Rfid { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string Adresse { get; set; }
        public string Region { get; set; }
        public string Gouvernement { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        
        public bool? PointedBus { get; set; }
        public bool? PointedIn { get; set; }
        public bool? PointedOut { get; set; }
        public ICollection<TrackingEvent>? TrackingEvents { get; set; }
        public string? EmployeeImageUrl { get; set; }  

        
    }
}