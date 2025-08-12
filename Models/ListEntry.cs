namespace longforum_backend.Models;

public class ListEntry
{
    public int Id { get; set; }
    public int Index { get; set; }
    
    public int ListId { get; set; }
    public List List { get; set; }
    
    public int ReviewId { get; set; }
    public Review Review { get; set; }
}