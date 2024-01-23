using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeBlog.Models
{
    public class User
    {
        [ForeignKey("PersonId")]

        public int PersonId { get; set; }

        [Key]
        public int UserId { get; set; }

        public String UserName { get; set; }

        public String Password { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public virtual Person Person { get; set; }
    }
}
