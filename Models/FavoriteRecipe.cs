using RecipeBlog.Models;
using System.ComponentModel.DataAnnotations;

namespace RecipeBlog.Models
{
    public class FavoriteRecipe
    {
        [Key]
        public int FavoriteRecipeId { get; set; }
        public int UserId { get; set; }
        public int RecipeId { get; set; }

        public virtual RecipePost RecipePost { get; set; }

        public virtual User User { get; set; }
    }
}
