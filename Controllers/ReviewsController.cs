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
    public class ReviewsController : ControllerBase
    {
        private readonly BlogContext _context;

        public ReviewsController(BlogContext context)
        {
            _context = context;
        }

        // GET: api/Reviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewDTO>>> GetReview()
        {
            if (_context.Review == null)
            {
                return NotFound();
            }

            var reviews = await _context.Review.ToListAsync();
            var reviewDTOs = reviews.Select(r => MapToDTO(r)).ToList();
            return Ok(reviewDTOs);
        }

        // GET: api/Reviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewDTO>> GetReview(int id)
        {
            if (_context.Review == null)
            {
                return NotFound();
            }

            var review = await _context.Review.FindAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            var reviewDTO = MapToDTO(review);
            return Ok(reviewDTO);
        }

        // PUT: api/Reviews/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReview(int id, ReviewDTO reviewDTO)
        {
            if (id != reviewDTO.ReviewId)
            {
                return BadRequest();
            }

            var existingReview = await _context.Review.FindAsync(id);

            if (existingReview == null)
            {
                return NotFound();
            }

            MapToEntity(existingReview, reviewDTO);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(id))
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

        // POST: api/Reviews
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReviewDTO>> PostReview(ReviewDTO reviewDTO)
        {
            if (_context.Review == null)
            {
                return Problem("Entity set 'BlogContext.Review' is null.");
            }

            var review = MapToEntity(reviewDTO);

            _context.Review.Add(review);
            await _context.SaveChangesAsync();

            var createdReviewDTO = MapToDTO(review);
            return CreatedAtAction("GetReview", new { id = createdReviewDTO.ReviewId }, createdReviewDTO);
        }

        // DELETE: api/Reviews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            if (_context.Review == null)
            {
                return NotFound();
            }

            var review = await _context.Review.FindAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            _context.Review.Remove(review);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReviewExists(int id)
        {
            return (_context.Review?.Any(e => e.ReviewId == id)).GetValueOrDefault();
        }

        private ReviewDTO MapToDTO(Review review)
        {
            return new ReviewDTO
            {
                ReviewId = review.ReviewId,
                // Map other properties from Review to ReviewDTO
            };
        }

        private void MapToEntity(Review existingReview, ReviewDTO reviewDTO)
        {
            // Map properties from ReviewDTO to existingReview
        }

        private Review MapToEntity(ReviewDTO reviewDTO)
        {
            return new Review
            {
                // Map properties from ReviewDTO to new Review entity
            };
        }
    }
}
