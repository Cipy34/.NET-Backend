using RecipeBlog.Data;
using Microsoft.EntityFrameworkCore;
using RecipeBlog.Services.UserService;
//using RecipeBlog.Services.PersonService;
using RecipeBlog.Controllers;
using RecipeBlog.Services.RecipePostService;
using RecipeBlog.Repositories;
using RecipeBlog.Services.ReviewService;
using RecipeBlog.Services.FavoriteRecipeService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BlogContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("BlogConnectionString")));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRecipePostService, RecipePostService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IFavoriteRecipeService, FavoriteRecipeService>();
//builder.Repositories.AddScoped<IUserRepository, UserRepository>();

//builder.Services.AddScoped<IPersonService, PersonService>();


var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();