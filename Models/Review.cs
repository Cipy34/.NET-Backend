using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeBlog.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public String Comment { get; set; }
        public DateTime PostDate { get; set; }
        public int RecipePostRecipeId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }

        public virtual RecipePost RecipePost { get; set; }

        public virtual User User { get; set; }
    }
}
