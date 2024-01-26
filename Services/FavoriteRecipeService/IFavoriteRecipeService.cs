using RecipeBlog.Models;
using RecipeBlog.Models.DTOs;
using System.Drawing.Drawing2D;

namespace RecipeBlog.Services.FavoriteRecipeService
{
    public interface IFavoriteRecipeService
    {
        Task<IEnumerable<FavoriteRecipeDTO>> GetFavoriteRecipes(int FavoriteRecipeId);
        Task AddFavoriteRecipe(FavoriteRecipe fr);
        Task<IEnumerable<FavoriteRecipeDTO>> DisplayFavoriteRecipes();
        Task<FavoriteRecipeDTO> IdByFavoriteRecipe(int id);
    }
}