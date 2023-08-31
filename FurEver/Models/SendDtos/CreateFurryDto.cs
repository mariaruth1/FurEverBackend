using System.ComponentModel.DataAnnotations;

namespace FurEver.Models.SendDtos;

public class CreateFurryDto
{
    public Guid FurryId { get; set; }
    public int Age { get; set; }
    public string? Fursona { get; set; }
    public string Username { get; set; } = null!;
    public int GenderId { get; set; }
    
    [EmailAddress]
    public string Email { get; set; } = null!;
    public string? PasswordHash { get; set; }

    public string? ProfileIntro { get; set; } = "";
    public string? ProfileBio { get; set; } = "";
    public string? ProfileMood { get; set; } = "";
    public string? ProfilePictureUrl { get; set; } = "";
}