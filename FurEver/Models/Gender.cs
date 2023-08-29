using System.ComponentModel.DataAnnotations;

namespace FurEver.Models;

public class Gender
{
    public int Id { get; set; }
    public string? GenderName { get; set; }
}