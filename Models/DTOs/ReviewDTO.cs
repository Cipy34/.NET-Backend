namespace RecipeBlog.Models.DTOs
{
    public class ReviewDTO
    {
        public int ReviewId { get; set; }
        public int Rating { get; set; }
        public String Comment { get; set; }
        public DateTime PostDate { get; set; }
    }
}
