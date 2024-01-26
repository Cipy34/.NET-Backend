using RecipeBlog.Models;
using RecipeBlog.Models.DTOs;
using System.Drawing.Drawing2D;

namespace RecipeBlog.Services.RecipePostService
{
    public interface IRecipePostService
    {
        Task<IEnumerable<RecipePostDTO>> GetRecipePosts(int RecipeId);
        Task AddRecipePost(RecipePost rp);
        Task<IEnumerable<RecipePostDTO>> DisplayRecipePosts();
        Task<RecipePostDTO> IdByRecipePost(int id);
    }
}