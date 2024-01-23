using System.ComponentModel.DataAnnotations;

namespace RecipeBlog.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }

        public string FirstName { get; set; } = " ";

        public string LastName { get; set; } = " ";

        public virtual User User { get; set; }
    }
}
