namespace longforum_backend.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string ProfilePic { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;

    public ICollection<Creator> FavoriteCreators { get; set; } = new List<Creator>();
    
    // Set up many-many relationship of users following
    public ICollection<User> Following { get; set; } = new List<User>();
    public ICollection<User> Followers { get; set; } = new List<User>();
    
    // Navigation Properties
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
    public ICollection<List> Lists { get; set; } = new List<List>();

}