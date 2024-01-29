using RecipeBlog.Models;
using RecipeBlog.Models.DTOs;
using System.Drawing.Drawing2D;

namespace RecipeBlog.Services.RecipePostService
{
    public interface IRecipePostService
    {
        Task AddPost(RecipePost r);
        Task<IEnumerable<RecipePostDTO>> DisplayPosts();
        Task<RecipePostDTO> PostById(int id);

        Task DeletePost(int id);
        Task UpdatePost(RecipePost r);
    }
}