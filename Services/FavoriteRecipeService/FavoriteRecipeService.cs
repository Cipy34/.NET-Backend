using RecipeBlog.Models;
using RecipeBlog.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using RecipeBlog.Data;
using RecipeBlog.Exceptions;
using System.ComponentModel;
using RecipeBlog.Exceptions;

namespace RecipeBlog.Services.FavoriteRecipeService
{
    public class FavoriteRecipeService : IFavoriteRecipeService
    {
        private readonly BlogContext _dbContext;
        public FavoriteRecipeService(BlogContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddFavoriteRecipe(FavoriteRecipe fr)
        {
            _dbContext.FavoriteRecipe.Add(fr);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<FavoriteRecipeDTO>> DisplayFavoriteRecipes()
        {
            var k = await _dbContext.FavoriteRecipe.ToListAsync();
            var fav = k.Select(x => new FavoriteRecipeDTO { FavoriteRecipeId = x.FavoriteRecipeId, UserId = x.UserId, RecipeId = x.RecipeId });
            return fav;
        }
        public async Task<FavoriteRecipeDTO> FavoriteRecipeById(int id)
        {
            var x = await _dbContext.FavoriteRecipe.FirstOrDefaultAsync(r => r.FavoriteRecipeId == id);
            if (x == null)
            {
                throw new Exceptie("Nu exista review ul");
            }
            else
                return new FavoriteRecipeDTO { FavoriteRecipeId = x.FavoriteRecipeId, UserId = x.UserId, RecipeId = x.RecipeId };
        }

        public async Task DeleteFavoriteRecipe(int id)
        {
            var fav = await _dbContext.FavoriteRecipe.FirstOrDefaultAsync(r => r.FavoriteRecipeId == id);
            _dbContext.FavoriteRecipe.Remove(fav);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateFavoriteRecipe(FavoriteRecipe fav)
        {
            _dbContext.Update(fav);
            await _dbContext.SaveChangesAsync();
        }
    }
}
