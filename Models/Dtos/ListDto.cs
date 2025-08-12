using longforum_backend.Enums;

namespace longforum_backend.Models.Dtos;

public class ListDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ListType Type { get; set; } = ListType.Normal;
    public ICollection<string> Tags = new List<string>();
    
    public int UserId { get; set; }
    
    public ICollection<ReviewDto> Reviews { get; set; } = new List<ReviewDto>();
    
    public ListDto(List? l)
    {
        if (l == null) return;
        
        Id = l.Id;
        Name = l.Name;
        Description = l.Description;
        Type = l.Type;
        Tags = l.Tags;
        UserId = l.UserId;
        Reviews = l.Entries.Select(e => new ReviewDto(e.Review)).ToList();
    }
}