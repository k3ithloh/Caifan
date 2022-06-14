namespace Caifan;

public class Review
{
    public int ReviewId { get; set; }
    public int Rating { get; set; }
    public int UserId { get; set; }
    public string Timestamp { get; set; } = string.Empty;
    public string UniversityName { get; set; } = string.Empty;
}