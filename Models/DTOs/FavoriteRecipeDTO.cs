namespace RecipeBlog.Models.DTOs
{
    public class FavoriteRecipeDTO
    {
        public int FavoriteRecipeId { get; set; }
        public int UserId { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public int RecipeId { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public int CookingTime { get; set; }
        public int Difficulty { get; set; }
        public String ImageUrl { get; set; }
    }
}
