using RecipeBlog.Models;
using RecipeBlog.Models.DTOs;
using System.Drawing.Drawing2D;

namespace RecipeBlog.Services.FavoriteRecipeService
{
    public interface IFavoriteRecipeService
    {
        Task AddFavoriteRecipe(FavoriteRecipe r);
        Task<IEnumerable<FavoriteRecipeDTO>> DisplayFavoriteRecipes();
        Task<FavoriteRecipeDTO> FavoriteRecipeById(int id);

        Task DeleteFavoriteRecipe(int id);
        Task UpdateFavoriteRecipe(FavoriteRecipe r);
    }
}