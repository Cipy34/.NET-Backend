using RecipeBlog.Models;
using RecipeBlog.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using RecipeBlog.Data;
using RecipeBlog.Exceptions;
using System.ComponentModel;
using RecipeBlog.Exceptions;
//using RecipeBlog.Repositories;

namespace RecipeBlog.Services.RecipePostService
{
    public class RecipePostService : IRecipePostService
    {
        private readonly BlogContext _dbContext;
        public RecipePostService(BlogContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddPost(RecipePost r)
        {
            _dbContext.RecipePost.Add(r);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<RecipePostDTO>> DisplayPosts()
        {
            var k = await _dbContext.RecipePost.ToListAsync();
            var recipe = k.Select(x => new RecipePostDTO { RecipeId = x.RecipeId, Title = x.Title, Description = x.Description, CookingTime = x.CookingTime, Difficulty = x.Difficulty, ImageUrl = x.ImageUrl });
            return recipe;
        }
        public async Task<RecipePostDTO> PostById(int id)
        {
            var x = await _dbContext.RecipePost.FirstOrDefaultAsync(r => r.RecipeId == id);
            if (x == null)
            {
                throw new Exceptie("Nu exista postarea");
            }
            else
                return new RecipePostDTO { RecipeId = x.RecipeId, Title = x.Title, Description = x.Description, CookingTime = x.CookingTime, Difficulty = x.Difficulty, ImageUrl = x.ImageUrl };
        }

        public async Task DeletePost(int id)
        {
            var recipe = await _dbContext.RecipePost.FirstOrDefaultAsync(r => r.RecipeId == id);
            _dbContext.RecipePost.Remove(recipe);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdatePost(RecipePost recipe)
        {
            _dbContext.Update(recipe);
            await _dbContext.SaveChangesAsync();
        }
    }
}