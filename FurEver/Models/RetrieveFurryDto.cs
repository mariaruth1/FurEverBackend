namespace FurEver.Models;

public class RetrieveFurryDto
{
    public Guid FurryId { get; set; }
    public int Age { get; set; }
    public string? Fursona { get; set; }
    public string Username { get; set; } = null!;
    public string GenderName { get; set; }
}