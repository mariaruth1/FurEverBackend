using System.ComponentModel.DataAnnotations;

namespace FurEver.Models;

public class Gender
{
    [Key]
    public string Name { get; set; }
    public string DisplayName { get; set; }
}