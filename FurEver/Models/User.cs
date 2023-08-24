using Microsoft.AspNetCore.Identity;

namespace FurEver.Models;

public class User : IdentityUser<Guid>
{
    public string? ProfileText { get; set; }
    public string? ProfileMood { get; set; }
    public string? ProfilePictureUrl { get; set; }
}