namespace longforum_backend.Models;

public class Review
{
    public int Id { get; set; }
    public int Burgers { get; set; }
    public bool IsLiked { get; set; }
    public string? ReviewText { get; set; }
    public ICollection<string> Tags { get; set; } = [];
    public int UserId { get; set; }
    public int VideoId { get; set; }
    
    // Navigation Properties
    public User User { get; set; }
    public Video Video { get; set; }
}