using RecipeBlog.Models;
using RecipeBlog.Models.DTOs;
using RecipeBlog.Services.ReviewService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using RecipeBlog.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace RecipeBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService recipeService)
        {
            _reviewService = recipeService;
        }

        [HttpPost]
        public async Task<IActionResult> AddReview([FromBody] ReviewDTO review)
        {
            // Create Post
            var aux = new Review
            {
                ReviewId = review.ReviewId,
                Comment = review.Comment,
                PostDate = review.PostDate,
                RecipePostRecipeId = review.RecipePostRecipeId,
                UserId = review.UserId,
                Rating = review.Rating
            };

            await _reviewService.AddReview(aux);

            return Ok();
        }

        [HttpGet]
        public async Task<IEnumerable<ReviewDTO>> DisplayReviews()
        {
            return await _reviewService.DisplayReviews();
        }

        [HttpGet("{reviewId}")]
        public async Task<IActionResult> ReviewById(int reviewId)
        {
            var reviews = await _reviewService.ReviewById(reviewId);
            return Ok(reviews);
        }

        [HttpDelete("{reviewId}")]
        public async Task<IActionResult> DeleteReview(int reviewId)
        {
            await _reviewService.DeleteReview(reviewId);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReview([FromBody] ReviewDTO review)
        {
            var aux = new Review
            {
                ReviewId = review.ReviewId,
                Comment = review.Comment,
                PostDate = review.PostDate,
                RecipePostRecipeId = review.RecipePostRecipeId,
                UserId = review.UserId,
                Rating = review.Rating
            };

            await _reviewService.UpdateReview(aux);

            return Ok();
        }
    }
}