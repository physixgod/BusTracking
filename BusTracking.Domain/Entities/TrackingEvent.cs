﻿using System;
using System.ComponentModel.DataAnnotations;

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
        public int RfidID { get; set; }
    }
}