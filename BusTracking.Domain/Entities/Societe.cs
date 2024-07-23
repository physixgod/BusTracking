using System.ComponentModel.DataAnnotations;

namespace BusTracking.Domain.ENTITIES;

public class Societe
{
    [Key]
    public int SocieteId { get; set; } 
    public string Name { get; set; }
    public ICollection<User> Users { get; set; }
}