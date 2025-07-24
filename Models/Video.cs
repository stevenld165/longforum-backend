using System.Collections.ObjectModel;
using longforum_backend.Enums;

namespace longforum_backend.Models;

public class Video
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Link { get; set; }
    public string? Thumbnail { get; set; }
    public int CreatorId { get; set; }
    public Platforms Platform { get; set; }
    public int Duration { get; set; }
    
    // Navigation Properties
    public Creator Creator { get; set; }
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
}