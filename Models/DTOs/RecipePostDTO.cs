namespace RecipeBlog.Models.DTOs
{
    public class RecipePostDTO
    {
        public String Title { get; set; }
        public String Description { get; set; }
        public int CookingTime { get; set; }
        public int Difficulty { get; set; }
        public String ImageUrl { get; set; }
    }
}
