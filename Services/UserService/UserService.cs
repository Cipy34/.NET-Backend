﻿using RecipeBlog.Models;
using RecipeBlog.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using RecipeBlog.Data;
using RecipeBlog.Exceptions;
using System.ComponentModel;
using RecipeBlog.Exceptions;

namespace RecipeBlog.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly BlogContext _dbContext;
        public UserService(BlogContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddUser(User user)
        {
            _dbContext.User.Add(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserDTO>> DisplayUsers()
        {
            var k = await _dbContext.User.ToListAsync();
            var user = k.Select(x => new UserDTO { UserId = x.UserId, UserName = x.UserName, Password = x.Password });
            return user;
        }
        public async Task<UserDTO> UserByID(int id)
        {
            var user = await _dbContext.User.FirstOrDefaultAsync(u => u.UserId == id);
            if (user == null)
            {
                throw new Exceptie("Nu exista User");
            }
            return new UserDTO { UserId = user.UserId, UserName = user.UserName, Password = user.Password };
        }
        public async Task<IEnumerable<UserDTO>> GetUserByFavoriteRecipes(int idfr)
        {
            var FavoriteUserList = await _dbContext.FavoriteRecipe
                .Where(fr => fr.RecipeId == idfr)
                .Include(fr => fr.User)
                .ToListAsync();
            var UserList = FavoriteUserList.Select(u => new UserDTO
            {
                UserId = u.User.UserId,
                UserName = u.User.UserName,
                Password = u.User.Password
            }).ToList();
            return UserList;
        }

        public Task<UserDTO> UserById(int id)
        {
            throw new NotImplementedException();
        }
    }
}