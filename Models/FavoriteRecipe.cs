using RecipeBlog.Models;

namespace RecipeBlog.Models
{
    public class FavoriteRecipe
    {
        public Guid FavoriteRecipeId { get; set; }

        public virtual RecipePost RecipePost { get; set; }

        public virtual User User { get; set; }
    }
}
