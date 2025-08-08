using longforum_backend.Enums;

namespace longforum_backend.Models.Dtos;

public class VideoDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;
    public string Thumbnail { get; set; } = string.Empty;
    public int CreatorId { get; set; }
    public string CreatorName { get; set; } = string.Empty;
    
    public Platforms Platform { get; set; }
    public int Duration { get; set; }

    public VideoDto (Video v)
    {
        Id = v.Id;
        Title = v.Title;
        Link = v.Link;
        Thumbnail = v.Thumbnail;
        CreatorId = v.CreatorId;
        CreatorName = v.Creator.Name;
        Platform = v.Platform;
        Duration = v.Duration;
    }
}