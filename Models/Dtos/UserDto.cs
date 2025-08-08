namespace longforum_backend.Models.Dtos;

public class UserDto
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string ProfilePic { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    
    // Computed before sending to client
    public ListDto Favorites { get; set; }
    public ICollection<ReviewDto> RecentReviews { get; set; } = new List<ReviewDto>();

    public UserDto(User u)
    {
        Id = u.Id;
        Username = u.Username;
        DisplayName = u.DisplayName;
        ProfilePic = u.ProfilePic;
        Bio = u.Bio;
    }
}