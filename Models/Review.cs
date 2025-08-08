namespace longforum_backend.Models;

public class Review
{
    public int Id { get; set; }
    public int Burgers { get; set; }
    public bool IsLiked { get; set; }
    public string ReviewText { get; set; } = string.Empty;
    public ICollection<string> Tags { get; set; } = new List<string>();
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    
    public int VideoId { get; set; }
    public Video Video { get; set; } = null!;
    
    // Navigation Properties
    public ICollection<List> Lists { get; set; } = new List<List>();
}