using Microsoft.EntityFrameworkCore;
using RecipeBlog.Data;
using RecipeBlog.Models;
using RecipeBlog.Models.DTOs;

namespace RecipeBlog.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BlogContext _dbContext;

        public UserRepository(BlogContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<UserDTO>> UserById(int id)
        {
            var user = await (from i in _dbContext.User
                              join p in _dbContext.Person on i.PersonId equals p.PersonId
                              where p.PersonId == id
                              select new UserDTO
                              {
                                  UserName = i.UserName,
                                  Password = i.Password,
                                  PersonId = i.PersonId,
                                  FirstName = p.FirstName,
                                  LastName = p.LastName
                              }).ToListAsync();

            return user;
        }
    }
}