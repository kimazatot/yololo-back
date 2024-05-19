using AutoMapper;
using LikeCommentFeedbackMicroservice.DTOs.Comment;
using LikeCommentFeedbackMicroservice.Models;
using LikeCommentFeedbackMicroservice.Repositories.Interfaces;
using LikeCommentFeedbackMicroservice.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

public class CommentService : ICommentService
{
    private readonly IBaseRepository<Comment> _commentRepository;
    private readonly IMapper _mapper;
    //private readonly Serilog.ILogger _logger;

    public CommentService(
        IBaseRepository<Comment> commentRepository,
        IMapper mapper
        /*Serilog.ILogger logger*/)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
        //_logger = logger;
    }

    public async Task<ReadCommentDto> CreateCommentAsync(CreateCommentDto dto)
    {
        if (dto == null)
        {
            throw new ArgumentNullException(nameof(dto));
        }

        var comment = _mapper.Map<Comment>(dto);

        try
        {
            await _commentRepository.CreateAsync(comment);
        }
        catch (Exception ex)
        {
            //_logger.Warning(ex, "Ошибка при создании комментария");
            //Log.Warning(ex, "Ошибка при создании комментария");
            throw new Exception("Ошибка при создании комментария", ex);
        }

        return _mapper.Map<ReadCommentDto>(comment);
    }

    public async Task<ReadCommentDto> DeleteCommentAsync(int id)
    {
        var comment = await _commentRepository.GetAll().FirstOrDefaultAsync(c => c.Id == id);
        if (comment == null)
        {
            return null;
        }

        try
        {
            await _commentRepository.RemoveAsync(comment);
        }
        catch (Exception ex)
        {
            //Log.Warning(ex, "Ошибка при удалении комментария");
            throw new Exception("Ошибка при удалении комментария", ex);
        }

        return _mapper.Map<ReadCommentDto>(comment);
    }

    public async Task<ReadCommentDto> GetCommentByIdAsync(int commentId)
    {
        var comment = await _commentRepository.GetAll().FirstOrDefaultAsync(c => c.Id == commentId);
        if (comment == null)
        {
            return null;
        }

        return _mapper.Map<ReadCommentDto>(comment);
    }

    public async Task<IEnumerable<ReadCommentDto>> GetCommentsAsync()
    {
        try
        {
            var comments = await _commentRepository.GetAll().ToListAsync();
            if (!comments.Any())
            {
                //Log.Information("Количество комментариев: 0");
                return Enumerable.Empty<ReadCommentDto>();
            }

            return _mapper.Map<IEnumerable<ReadCommentDto>>(comments);
        }
        catch (Exception ex)
        {
            //Log.Warning(ex, "Произошла ошибка при получении комментариев");
            return Enumerable.Empty<ReadCommentDto>();
        }
    }

    public async Task<IEnumerable<ReadCommentDto>> GetCommentsByProductAsync(int productId)
    {
        try
        {
            var comments = await _commentRepository.GetAll().Where(c => c.ProductId == productId).ToListAsync();
            if (!comments.Any())
            {
                //Log.Information("Количество комментариев: 0");
                return Enumerable.Empty<ReadCommentDto>();
            }

            return _mapper.Map<IEnumerable<ReadCommentDto>>(comments);
        }
        catch (Exception ex)
        {
            //Log.Warning(ex, "Произошла ошибка при получении комментариев");
            return Enumerable.Empty<ReadCommentDto>();
        }
    }

    public async Task<ReadCommentDto> UpdateCommentAsync(UpdateCommentDto dto)
    {
        var comment = await _commentRepository.GetAll().FirstOrDefaultAsync(c => c.Id == dto.Id);
        if (comment == null)
        {
            return null;
        }

        comment.Content = dto.Content;
        comment.ReviewId = dto.ReviewId;
        comment.ProductId = dto.ProductId;

        try
        {
            var updatedComment = await _commentRepository.UpdateAsync(comment);
            return _mapper.Map<ReadCommentDto>(updatedComment);
        }
        catch (Exception ex)
        {
            //Log.Warning(ex, "Ошибка при обновлении комментария");
            throw new Exception("Ошибка при обновлении комментария", ex);
        }
    }
}
