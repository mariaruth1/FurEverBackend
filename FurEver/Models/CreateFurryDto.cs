using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FurEver.Models;

public class CreateFurryDto
{
    public Guid FurryId { get; set; }
    public int Age { get; set; }
    public string? Fursona { get; set; }
    public string Username { get; set; } = null!;
    public int GenderId { get; set; }
    
    [EmailAddress]
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }
}