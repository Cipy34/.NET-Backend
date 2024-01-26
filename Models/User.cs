using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeBlog.Models
{
    public class User
    {
        public int UserId { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        

        public int PersonId { get; set; }
        public virtual Person Person { get; set; }

        public ICollection<FavoriteRecipe>? FavoriteRecipes { get; set; }

    }
}
