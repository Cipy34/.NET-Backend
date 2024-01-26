using RecipeBlog.Models;
using RecipeBlog.Models.DTOs;
using System.Drawing.Drawing2D;

namespace RecipeBlog.Services.ReviewService
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewDTO>> GetReviews(int ReviewId);
        Task AddReview(Review r);
        Task<IEnumerable<ReviewDTO>> DisplayReviews();
        Task<ReviewDTO> IdByReview(int id);
    }
}