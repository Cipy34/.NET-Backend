using RecipeBlog.Models;
using RecipeBlog.Models.DTOs;
using RecipeBlog.Services.FavoriteRecipeService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using RecipeBlog.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace RecipeBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteRecipeController : ControllerBase
    {
        private readonly IFavoriteRecipeService _favoriterecipeService;

        public FavoriteRecipeController(IFavoriteRecipeService recipeService)
        {
            _favoriterecipeService = recipeService;
        }

        [HttpPost]
        public async Task<IActionResult> AddFavoriteRecipe([FromBody] FavoriteRecipeDTO fav)
        {
            // Create FavoriteRecipe
            var aux = new FavoriteRecipe
            {
                FavoriteRecipeId = fav.FavoriteRecipeId,
                UserId = fav.UserId,
                RecipeId = fav.RecipeId
            };

            await _favoriterecipeService.AddFavoriteRecipe(aux);

            return Ok();
        }

        [HttpGet]
        public async Task<IEnumerable<FavoriteRecipeDTO>> DisplayFavoriteRecipes()
        {
            return await _favoriterecipeService.DisplayFavoriteRecipes();
        }

        [HttpGet("{favoriterecipeId}")]
        public async Task<IActionResult> FavoriteRecipeById(int favoriterecipeId)
        {
            var fav = await _favoriterecipeService.FavoriteRecipeById(favoriterecipeId);
            return Ok(fav);
        }

        [HttpDelete("{favoriterecipeId}")]
        public async Task<IActionResult> DeleteFavoriteRecipe(int favoriterecipeId)
        {
            await _favoriterecipeService.DeleteFavoriteRecipe(favoriterecipeId);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFavoriteRecipe([FromBody] FavoriteRecipeDTO fav)
        {
            var aux = new FavoriteRecipe
            {
                FavoriteRecipeId = fav.FavoriteRecipeId,
                UserId = fav.UserId,
                RecipeId = fav.RecipeId
            };

            await _favoriterecipeService.UpdateFavoriteRecipe(aux);

            return Ok();
        }
    }
}