using System.ComponentModel.DataAnnotations;

namespace FurEver.Models;

public class Gender
{
    public int GenderId { get; set; }
    public string? GenderName { get; set; }
}