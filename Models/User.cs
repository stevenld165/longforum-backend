namespace longforum_backend.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string? DisplayName { get; set; }
    public string? ProfilePic { get; set; }
    public string? Bio { get; set; }
    
    // Set up many-many relationship of users following
    public ICollection<User>? Following { get; set; }
    
    // Navigation Properties
    public ICollection<Review>? Reviews { get; set; }
    
}