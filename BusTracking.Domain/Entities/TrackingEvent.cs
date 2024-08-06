using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;

namespace BusTracking.Domain.ENTITIES
{
    public class TrackingEvent
    {
        [Key]
        public int TrackingEventID { get; set; }
        public DateTime Timestamp { get; set; }
        public int DeviceID { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public int Rfid { get; set; } 
        public Employees Employees { get; set; } 
        public DateTime PointingIn { get; set; }
        public DateTime PointingOut { get; set; }
        
    }
}