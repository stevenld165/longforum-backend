namespace longforum_backend.Models;

public class User
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public string? DisplayName { get; set; }
    public string? ProfilePic { get; set; }
    public string? Bio { get; set; }

    public ICollection<Creator> FavoriteCreators { get; set; }
    
    // Set up many-many relationship of users following
    public ICollection<User> Following { get; set; }
    
    // Navigation Properties
    public ICollection<Review> Reviews { get; set; }
    
}