using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BusTracking.Domain.ENTITIES;

public class User
{
    [Key]
    public string Login { get; set; }
    
    public string Password { get; set; }
    public Societe? Societe { get; set; }
    public int? SocieteId { get; set; }

}