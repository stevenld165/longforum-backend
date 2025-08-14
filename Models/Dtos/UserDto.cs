namespace longforum_backend.Models.Dtos;

public class UserDto
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string ProfilePic { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;

    public UserDto(User u)
    {
        Id = u.Id;
        Username = u.Username;
        DisplayName = u.DisplayName;
        ProfilePic = u.ProfilePic;
        Bio = u.Bio;
    }
}