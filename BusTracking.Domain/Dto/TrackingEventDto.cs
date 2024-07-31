public class TrackingEventDto
{
    public int RFID { get; set; }
    public string EmployeePhotoUrl { get; set; }
    public string EmployeeFirstName { get; set; }
    public string EmployeeLastName { get; set; }
    public DateTime Timestamp { get; set; }
    public double Longitude { get; set; }
    public double Latitude { get; set; }
}