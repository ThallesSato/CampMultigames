using System.ComponentModel.DataAnnotations;

namespace CampMultigames.Domain.Models;

public class BaseEntity 
{
    [Key]
    public int Id { get; set; }
}