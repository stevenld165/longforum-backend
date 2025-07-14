namespace longforum_backend.Models;

public class Creator
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    // Navigation Properties
    public ICollection<Video> Videos { get; set; }
}