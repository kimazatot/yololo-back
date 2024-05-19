using LikeCommentFeedbackMicroservice.Models;
using LikeCommentFeedbackMicroservice.Repositories.Interfaces;
using LikeCommentFeedbackMicroservice.Repositories;
using LikeCommentFeedbackMicroservice.Services.Interfaces;
using LikeCommentFeedbackMicroservice.Services;
using LikeCommentFeedbackMicroservice.Mapping;
using LikeCommentFeedbackMicroservice.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Host.UseSerilog();

builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ILikeService, LikeService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IBaseRepository<Comment>, BaseRepository<Comment>>();
builder.Services.AddScoped<IBaseRepository<Review>, BaseRepository<Review>>();
builder.Services.AddScoped<IBaseRepository<Like>, BaseRepository<Like>>();

builder.Services.AddAutoMapper(typeof(CommentMapping));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL"));
});

//Log.Logger = new LoggerConfiguration()
//    .MinimumLevel.Warning()
//    .WriteTo.Console()
//    .CreateLogger();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
