using System.ComponentModel.DataAnnotations;

namespace FurEver.Models.GetDtos;

public class RetrieveFurryWithProfileDto
{
    public Guid FurryId { get; set; }
    
    public int Age { get; set; }
    public string? Fursona { get; set; }
    public string Username { get; set; } = null!;
    public string GenderName { get; set; } = null!;
    
    public string? ProfileIntro { get; set; }
    public string? ProfileBio { get; set; }
    public string? ProfileMood { get; set; }
    public string? ProfilePictureUrl { get; set; }
}