using RecipeBlog.Models;
using RecipeBlog.Models.DTOs;

namespace RecipeBlog.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDTO>> UserById(int id);
    }
}