using AutoMapper;
using LikeCommentFeedbackMicroservice.DTOs.Comment;
using LikeCommentFeedbackMicroservice.DTOs.Review;
using LikeCommentFeedbackMicroservice.Models;
using LikeCommentFeedbackMicroservice.Repositories.Interfaces;
using LikeCommentFeedbackMicroservice.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.ComponentModel.Design;

namespace LikeCommentFeedbackMicroservice.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IBaseRepository<Review> _reviewRepository;
        private readonly IMapper _mapper;

        public ReviewService(
            IBaseRepository<Review> reviewRepository,
            IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public async Task<ReadReviewDto> CreateReviewAsync(CreateReviewDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            var review = _mapper.Map<Review>(dto);

            try
            {
                await _reviewRepository.CreateAsync(review);
            }
            catch (Exception ex)
            {
                //Log.Warning(ex, "Ошибка при создании review");
                throw new Exception("Ошибка при создании review", ex);
            }

            return _mapper.Map<ReadReviewDto>(review);
        }

        public async Task<ReadReviewDto> DeleteReviewAsync(int reviewId)
        {
            var review = await _reviewRepository.GetAll().FirstOrDefaultAsync(c => c.Id == reviewId);
            if (review == null)
            {
                return null;
            }

            try
            {
                await _reviewRepository.RemoveAsync(review);
            }
            catch (Exception ex)
            {
                //Log.Warning(ex, "Ошибка при удалении review");
                throw new Exception("Ошибка при удалении review", ex);
            }

            return _mapper.Map<ReadReviewDto>(review);
        }

        public async Task<IEnumerable<ReadReviewDto>> GetReviewsAsync()
        {
            try
            {
                var reviews = await _reviewRepository.GetAll().ToListAsync();

                if (!reviews.Any())
                {
                    //Log.Information("Количество reviews: 0");
                    return Enumerable.Empty<ReadReviewDto>();
                }

                return _mapper.Map<IEnumerable<ReadReviewDto>>(reviews);
            }
            catch(Exception ex)
            {
                //Log.Warning(ex, "Произошла ошибка при получении reviews");
                return Enumerable.Empty<ReadReviewDto>();
            }
        }

        public async Task<ReadReviewDto> GetReviewByIdAsync(int reviewId)
        {
            var comment = await _reviewRepository.GetAll().FirstOrDefaultAsync(c => c.Id == reviewId);
            if (comment == null)
            {
                return null;
            }

            return _mapper.Map<ReadReviewDto>(comment);
        }

        public async Task<IEnumerable<ReadReviewDto>> GetReviewsByProductAsync(int productId)
        {
            try
            {
                var reviews = await _reviewRepository.GetAll().Where(c => c.ProductId == productId).ToListAsync();
                if (!reviews.Any())
                {
                    //Log.Information("Количество reviews: 0");
                    return Enumerable.Empty<ReadReviewDto>();
                }

                return _mapper.Map<IEnumerable<ReadReviewDto>>(reviews);
            }
            catch (Exception ex)
            {
                //Log.Warning(ex, "Произошла ошибка при получении reviews");
                return Enumerable.Empty<ReadReviewDto>();
            }
        }

        public async Task<ReadReviewDto> UpdateReviewAsync(UpdateReviewDto dto)
        {
            var review = await _reviewRepository.GetAll().FirstOrDefaultAsync(c => c.Id == dto.Id);
            if (review == null)
            {
                return null;
            }

            //review.ProductId = dto.ProductId;
            review.UserId = dto.UserId;
            review.Content = dto.Content;
            review.Rating = dto.Rating;

            try
            {
                var updatedReview = await _reviewRepository.UpdateAsync(review);
                return _mapper.Map<ReadReviewDto>(updatedReview);
            }
            catch (Exception ex)
            {
                //Log.Warning(ex, "Ошибка при обновлении review");
                throw new Exception("Ошибка при обновлении review", ex);
            }
        }
    }
}
