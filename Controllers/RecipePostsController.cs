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
    public class RecipePostsController : ControllerBase
    {
        private readonly BlogContext _context;

        public RecipePostsController(BlogContext context)
        {
            _context = context;
        }

        // GET: api/RecipePosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipePostDTO>>> GetRecipePost()
        {
            if (_context.RecipePost == null)
            {
                return NotFound();
            }

            var recipePosts = await _context.RecipePost.ToListAsync();
            var recipePostDTOs = recipePosts.Select(rp => MapToDTO(rp)).ToList();
            return Ok(recipePostDTOs);
        }

        // GET: api/RecipePosts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecipePostDTO>> GetRecipePost(int id)
        {
            if (_context.RecipePost == null)
            {
                return NotFound();
            }

            var recipePost = await _context.RecipePost.FindAsync(id);

            if (recipePost == null)
            {
                return NotFound();
            }

            var recipePostDTO = MapToDTO(recipePost);
            return Ok(recipePostDTO);
        }

        // PUT: api/RecipePosts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipePost(int id, RecipePostDTO recipePostDTO)
        {
            if (id != recipePostDTO.RecipeId)
            {
                return BadRequest();
            }

            var existingRecipePost = await _context.RecipePost.FindAsync(id);

            if (existingRecipePost == null)
            {
                return NotFound();
            }

            MapToEntity(existingRecipePost, recipePostDTO);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipePostExists(id))
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

        // POST: api/RecipePosts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RecipePostDTO>> PostRecipePost(RecipePostDTO recipePostDTO)
        {
            if (_context.RecipePost == null)
            {
                return Problem("Entity set 'BlogContext.RecipePost' is null.");
            }

            var recipePost = MapToEntity(recipePostDTO);

            _context.RecipePost.Add(recipePost);
            await _context.SaveChangesAsync();

            var createdRecipePostDTO = MapToDTO(recipePost);
            return CreatedAtAction("GetRecipePost", new { id = createdRecipePostDTO.RecipeId }, createdRecipePostDTO);
        }

        // DELETE: api/RecipePosts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipePost(int id)
        {
            if (_context.RecipePost == null)
            {
                return NotFound();
            }

            var recipePost = await _context.RecipePost.FindAsync(id);

            if (recipePost == null)
            {
                return NotFound();
            }

            _context.RecipePost.Remove(recipePost);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecipePostExists(int id)
        {
            return (_context.RecipePost?.Any(e => e.RecipeId == id)).GetValueOrDefault();
        }

        private RecipePostDTO MapToDTO(RecipePost recipePost)
        {
            return new RecipePostDTO
            {
                RecipeId = recipePost.RecipeId,
                // Map other properties from RecipePost to RecipePostDTO
            };
        }

        private void MapToEntity(RecipePost existingRecipePost, RecipePostDTO recipePostDTO)
        {
            // Map properties from RecipePostDTO to existingRecipePost
        }

        private RecipePost MapToEntity(RecipePostDTO recipePostDTO)
        {
            return new RecipePost
            {
                // Map properties from RecipePostDTO to new RecipePost entity
            };
        }
    }
}
