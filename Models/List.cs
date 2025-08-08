using longforum_backend.Enums;

namespace longforum_backend.Models;

public class List
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ListType Type { get; set; } = ListType.Normal;
    public ICollection<string> Tags = new List<string>();
    
    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public Review[] Reviews { get; set; } = [];
}