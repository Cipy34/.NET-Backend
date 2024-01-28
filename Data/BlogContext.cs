using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RecipeBlog.Models;

namespace RecipeBlog.Data
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<RecipePost> RecipePost { get; set; }
        public DbSet<FavoriteRecipe> FavoriteRecipe { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<User> User { get; set; }

        public DbSet<Person> Person { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FavoriteRecipe>()
                .HasKey(fr => new { fr.RecipeId, fr.UserId });

            modelBuilder.Entity<FavoriteRecipe>()
                .HasOne(fr => fr.User)
                .WithMany(u => u.FavoriteRecipes)
                .HasForeignKey(fr => fr.UserId);

            modelBuilder.Entity<FavoriteRecipe>()
                .HasOne(fr => fr.RecipePost)
                .WithMany(rp => rp.FavoriteRecipes)
                .HasForeignKey(fr => fr.RecipeId);
        }
    }
}
