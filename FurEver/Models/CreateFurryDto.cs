using Microsoft.AspNetCore.Identity;

namespace FurEver.Models;

public class CreateFurryDto
{
    public Guid Id { get; set; }
    public int Age { get; set; }
    public string? Fursona { get; set; }
    public string Username { get; set; } = null!;
    public int GenderId { get; set; }
}