using RecipeBlog.Models;
using RecipeBlog.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using RecipeBlog.Data;
using RecipeBlog.Exceptions;
using System.ComponentModel;
using RecipeBlog.Exceptions;
//using RecipeBlog.Repositories;

namespace RecipeBlog.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly BlogContext _dbContext;
        public UserService(BlogContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddUser(User user, Person pers)
        {


            if (!_dbContext.Person.Any(p => p.PersonId == pers.PersonId))
            {
                _dbContext.Person.Add(pers);
                await _dbContext.SaveChangesAsync();
            }

            //Console.WriteLine($"PersonId: {user.PersonId}");
            user.PersonId = _dbContext.Person.Max(p => p.PersonId);

            _dbContext.User.Add(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserDTO>> DisplayUsers()
        {
            var k = await _dbContext.User.Include(u => u.Person).ToListAsync();
            var user = k.Select(x => new UserDTO { PersonId = x.PersonId, UserName = x.UserName, Password = x.Password, FirstName = x.Person.FirstName, LastName = x.Person.LastName });
            return user;
        }
        public async Task<UserDTO> UserById(int id)
        {
            var user = await _dbContext.User.Include(p => p.Person).FirstOrDefaultAsync(u => u.UserId == id);
            if (user == null)
            {
                throw new Exceptie("Nu exista user");
            }
            else
                return new UserDTO { PersonId = user.PersonId, UserName = user.UserName, Password = user.Password, FirstName = user.Person.FirstName, LastName = user.Person.LastName };
        }
        public async Task<IEnumerable<UserDTO>> GetUserByFavoriteRecipes(int idfr)
        {
            var FavoriteUserList = await _dbContext.FavoriteRecipe
                .Where(fr => fr.RecipeId == idfr)
                .Include(fr => fr.User)
                .ToListAsync();
            var UserList = FavoriteUserList.Select(u => new UserDTO
            {
                //UserId = u.User.UserId,
                UserName = u.User.UserName,
                Password = u.User.Password
            }).ToList();
            return UserList;
        }

        public async Task DeleteUser(int id)
        {
            var user = await _dbContext.User.FirstOrDefaultAsync(u => u.UserId == id);
            _dbContext.User.Remove(user);
            await _dbContext.SaveChangesAsync();

            var pers = await _dbContext.Person.FirstOrDefaultAsync(u => u.PersonId == id);
            _dbContext.Person.Remove(pers);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUser(User user, Person pers)
        {
            user.UserId = user.PersonId;
            _dbContext.Update(user);
            await _dbContext.SaveChangesAsync();

            pers.PersonId = user.PersonId;
            _dbContext.Update(pers);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<UserDTO> UserLogin(string username, string password)
        {
            var user = await _dbContext.User.FirstOrDefaultAsync(u => u.UserName == username);
            if (user == null)
            {
                throw new Exceptie("Nu exista user");
            }
            else
            if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                throw new Exceptie("Parola gresita");
            }
                
            else
                return new UserDTO { PersonId = user.PersonId, UserName = user.UserName, Password = user.Password};
        }
    }
}