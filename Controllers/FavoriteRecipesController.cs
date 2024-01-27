using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeBlog.Data;
using RecipeBlog.Models;
using RecipeBlog.Models.DTOs;

namespace RecipeBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteRecipesController : ControllerBase
    {
        private readonly BlogContext _context;

        public FavoriteRecipesController(BlogContext context)
        {
            _context = context;
        }

        // GET: api/FavoriteRecipes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FavoriteRecipeDTO>>> GetFavoriteRecipe()
        {
            if (_context.FavoriteRecipe == null)
            {
                return NotFound();
            }

            var favoriteRecipes = await _context.FavoriteRecipe.ToListAsync();
            var favoriteRecipeDTOs = favoriteRecipes.Select(fr => MapToDTO(fr)).ToList();
            return Ok(favoriteRecipeDTOs);
        }

        // GET: api/FavoriteRecipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FavoriteRecipeDTO>> GetFavoriteRecipe(int id)
        {
            if (_context.FavoriteRecipe == null)
            {
                return NotFound();
            }

            var favoriteRecipe = await _context.FavoriteRecipe.FindAsync(id);

            if (favoriteRecipe == null)
            {
                return NotFound();
            }

            var favoriteRecipeDTO = MapToDTO(favoriteRecipe);
            return Ok(favoriteRecipeDTO);
        }

        // PUT: api/FavoriteRecipes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavoriteRecipe(int id, FavoriteRecipeDTO favoriteRecipeDTO)
        {
            if (id != favoriteRecipeDTO.FavoriteRecipeId)
            {
                return BadRequest();
            }

            var existingFavoriteRecipe = await _context.FavoriteRecipe.FindAsync(id);

            if (existingFavoriteRecipe == null)
            {
                return NotFound();
            }

            MapToEntity(existingFavoriteRecipe, favoriteRecipeDTO);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavoriteRecipeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FavoriteRecipes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FavoriteRecipeDTO>> PostFavoriteRecipe(FavoriteRecipeDTO favoriteRecipeDTO)
        {
            if (_context.FavoriteRecipe == null)
            {
                return Problem("Entity set 'BlogContext.FavoriteRecipe' is null.");
            }

            var favoriteRecipe = MapToEntity(favoriteRecipeDTO);

            _context.FavoriteRecipe.Add(favoriteRecipe);
            await _context.SaveChangesAsync();

            var createdFavoriteRecipeDTO = MapToDTO(favoriteRecipe);
            return CreatedAtAction("GetFavoriteRecipe", new { id = createdFavoriteRecipeDTO.FavoriteRecipeId }, createdFavoriteRecipeDTO);
        }

        // DELETE: api/FavoriteRecipes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavoriteRecipe(int id)
        {
            if (_context.FavoriteRecipe == null)
            {
                return NotFound();
            }

            var favoriteRecipe = await _context.FavoriteRecipe.FindAsync(id);

            if (favoriteRecipe == null)
            {
                return NotFound();
            }

            _context.FavoriteRecipe.Remove(favoriteRecipe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FavoriteRecipeExists(int id)
        {
            return (_context.FavoriteRecipe?.Any(e => e.FavoriteRecipeId == id)).GetValueOrDefault();
        }

        private FavoriteRecipeDTO MapToDTO(FavoriteRecipe favoriteRecipe)
        {
            return new FavoriteRecipeDTO
            {
                FavoriteRecipeId = favoriteRecipe.FavoriteRecipeId,
                // Map other properties from FavoriteRecipe to FavoriteRecipeDTO
            };
        }

        private void MapToEntity(FavoriteRecipe existingFavoriteRecipe, FavoriteRecipeDTO favoriteRecipeDTO)
        {
            // Map properties from FavoriteRecipeDTO to existingFavoriteRecipe
        }

        private FavoriteRecipe MapToEntity(FavoriteRecipeDTO favoriteRecipeDTO)
        {
            return new FavoriteRecipe
            {
                // Map properties from FavoriteRecipeDTO to new FavoriteRecipe entity
            };
        }
    }
}
