namespace FurEver.Models.SendDtos;

public class UpdateFurryProfileDto
{
    public Guid FurryId { get; set; }
    public string? ProfileIntro { get; set; }
    public string? ProfileBio { get; set; }
    public string? ProfileMood { get; set; }
    public string? ProfilePictureUrl { get; set; }
}