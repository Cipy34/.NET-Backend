using RecipeBlog.Models;
using RecipeBlog.Models.DTOs;
using System.Drawing.Drawing2D;

namespace RecipeBlog.Services.UserService
{
    public interface IUserService
    {
        Task AddUser(User u);
        Task<IEnumerable<UserDTO>> DisplayUsers();
        Task<UserDTO> UserById(int id);
    }
}