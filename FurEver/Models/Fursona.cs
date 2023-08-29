using System.ComponentModel.DataAnnotations;

namespace FurEver.Models;

public class Fursona
{
    [Key]
    public string Name { get; set; }
    public string DisplayName { get; set; }
}