using RecipeBlog.Models;
using RecipeBlog.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using RecipeBlog.Data;
using RecipeBlog.Exceptions;
using System.ComponentModel;
using RecipeBlog.Exceptions;

namespace RecipeBlog.Services.ReviewService
{
    public class ReviewService : IReviewService
    {
        private readonly BlogContext _dbContext;
        public ReviewService(BlogContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddReview(Review r)
        {
            _dbContext.Review.Add(r);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ReviewDTO>> DisplayReviews()
        {
            var k = await _dbContext.Review.ToListAsync();
            var review = k.Select(x => new ReviewDTO { ReviewId = x.ReviewId, Comment = x.Comment, PostDate = x.PostDate, RecipePostRecipeId = x.RecipePostRecipeId, UserId = x.UserId, Rating = x.Rating });
            return review;
        }
        public async Task<ReviewDTO> ReviewById(int id)
        {
            var x = await _dbContext.Review.FirstOrDefaultAsync(r => r.ReviewId == id);
            if (x == null)
            {
                throw new Exceptie("Nu exista review ul");
            }
            else
                return new ReviewDTO { ReviewId = x.ReviewId, Comment = x.Comment, PostDate = x.PostDate, RecipePostRecipeId = x.RecipePostRecipeId, UserId = x.UserId, Rating = x.Rating };
        }

        public async Task DeleteReview(int id)
        {
            var review = await _dbContext.Review.FirstOrDefaultAsync(r => r.ReviewId == id);
            _dbContext.Review.Remove(review);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateReview(Review review)
        {
            _dbContext.Update(review);
            await _dbContext.SaveChangesAsync();
        }
    }
}
