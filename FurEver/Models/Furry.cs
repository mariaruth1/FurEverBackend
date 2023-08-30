using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FurEver.Models;

public class Furry
{
    public Guid FurryId { get; set; }
    public string? Username { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }
    
    public string? Fursona { get; set; }
    public int Age { get; set; }
    public string? Gender { get; set; }
    
    //Profile info
    public string? ProfileIntro { get; set; }
    public string? ProfileBio { get; set; }
    public string? ProfileMood { get; set; }
    public string? ProfilePictureUrl { get; set; }
}