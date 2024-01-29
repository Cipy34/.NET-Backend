using RecipeBlog.Models;
using RecipeBlog.Models.DTOs;
using System.Drawing.Drawing2D;

namespace RecipeBlog.Services.ReviewService
{
    public interface IReviewService
    {
        Task AddReview(Review r);
        Task<IEnumerable<ReviewDTO>> DisplayReviews();
        Task<ReviewDTO> ReviewById(int id);

        Task DeleteReview(int id);
        Task UpdateReview(Review r);
    }
}