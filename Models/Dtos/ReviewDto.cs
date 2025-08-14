namespace longforum_backend.Models.Dtos;

public class ReviewDto
{
    public int Id { get; set; }
    public int Burgers { get; set; }
    public bool IsLiked { get; set; }
    public string ReviewText { get; set; }
    public string CreatedOn { get; set; }
    public ICollection<string> Tags { get; set; }
    
    public int UserId { get; set; }

    public VideoDto Video { get; set; }
    public int VideoId { get; set; }

    public ReviewDto(Review r)
    {
        Id = r.Id;
        Burgers = r.Burgers;
        IsLiked = r.IsLiked;
        ReviewText = r.ReviewText;
        CreatedOn = r.CreatedOn.ToShortDateString();
        Tags = r.Tags;
        UserId = r.UserId;
        VideoId = r.VideoId;
        Video = new VideoDto(r.Video);
    }
}