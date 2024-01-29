using RecipeBlog.Models;
using RecipeBlog.Models.DTOs;
using RecipeBlog.Services.RecipePostService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using RecipeBlog.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace RecipeBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipePostController : ControllerBase
    {
        private readonly IRecipePostService _recipeService;

        public RecipePostController(IRecipePostService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpPost]
        public async Task<IActionResult> AddPost([FromBody] RecipePostDTO recipe)
        {
            // Create Post
            var aux = new RecipePost
            {
                RecipeId = recipe.RecipeId,
                Title = recipe.Title,
                Description = recipe.Description,
                CookingTime = recipe.CookingTime,
                Difficulty = recipe.Difficulty,
                ImageUrl = recipe.ImageUrl
            };

            await _recipeService.AddPost(aux);

            return Ok();
        }

        [HttpGet]
        public async Task<IEnumerable<RecipePostDTO>> DisplayPosts()
        {
            return await _recipeService.DisplayPosts();
        }

        [HttpGet("{recipeId}")]
        public async Task<IActionResult> PostById(int recipeId)
        {
            var recipes = await _recipeService.PostById(recipeId);
            return Ok(recipes);
        }

        [HttpDelete("{recipeId}")]
        public async Task<IActionResult> DeletePost(int recipeId)
        {
            await _recipeService.DeletePost(recipeId);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePost([FromBody] RecipePostDTO recipe)
        {
            var aux = new RecipePost
            {
                RecipeId = recipe.RecipeId,
                Title = recipe.Title,
                Description = recipe.Description,
                CookingTime = recipe.CookingTime,
                Difficulty = recipe.Difficulty,
                ImageUrl = recipe.ImageUrl
            };

            await _recipeService.UpdatePost(aux);

            return Ok();
        }
    }
}