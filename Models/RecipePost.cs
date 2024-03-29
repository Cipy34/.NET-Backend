﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeBlog.Models
{
    public class RecipePost
    {
        [Key]
        public int RecipeId { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public int CookingTime { get; set; }
        public int Difficulty { get; set; }
        public String ImageUrl { get; set; }

        public ICollection<FavoriteRecipe>? FavoriteRecipes { get; set; }
        public ICollection<Review>? Reviews { get; set; }
    }
}
