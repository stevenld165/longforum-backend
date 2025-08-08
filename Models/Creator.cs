namespace longforum_backend.Models;

public class Creator
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    // Navigation Properties
    public ICollection<Video> Videos { get; set; } = new List<Video>();
    public ICollection<User> UsersFavoritedBy { get; set; } = new List<User>();
}