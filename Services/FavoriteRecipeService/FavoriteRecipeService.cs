using RecipeBlog.Data;
using RecipeBlog.Models;
using RecipeBlog.Models.DTOs;
using RecipeBlog.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace RecipeBlog.Services.FavoriteRecipeService
{
    public class FavoriteRecipeService
    {
        private readonly BlogContext _dbContext;
        public FavoriteRecipeService(BlogContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddFavoriteRecipe(int idr, int idu)
        {
            var user = await _dbContext.User.FirstOrDefaultAsync(u => u.UserId == idu);
            var post = await _dbContext.RecipePost.FirstOrDefaultAsync(rp => rp.RecipeId == idr);
            if (post == null || user == null)
            {
                throw new Exceptie("Nu exista postarea sau user-ul");
            }
            FavoriteRecipe fr = new FavoriteRecipe();
            fr.UserId = idu;
            fr.RecipeId = idr;
            fr.User = user;
            fr.RecipePost = post;
            _dbContext.FavoriteRecipe.Add(fr);
            await _dbContext.SaveChangesAsync();
        }
    }
}