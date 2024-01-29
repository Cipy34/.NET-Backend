namespace RecipeBlog.Models.DTOs
{
    public class FavoriteRecipeDTO
    {
        public int FavoriteRecipeId { get; set; }
        public int UserId { get; set; }
        public int RecipeId { get; set; }
    }
}
