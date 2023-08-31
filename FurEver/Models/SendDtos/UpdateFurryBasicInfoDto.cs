using System.ComponentModel.DataAnnotations;

namespace FurEver.Models.SendDtos;

public class UpdateFurryBasicInfoDto
{
    public Guid FurryId { get; set; }
    public int Age { get; set; }
    public string? Fursona { get; set; }
    public string Username { get; set; } = null!;
    public int GenderId { get; set; }
    
    [EmailAddress]
    public string Email { get; set; } = null!;
    public string? PasswordHash { get; set; }
}