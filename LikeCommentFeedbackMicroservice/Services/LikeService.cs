using AutoMapper;
using LikeCommentFeedbackMicroservice.DTOs.Like;
using LikeCommentFeedbackMicroservice.Models;
using LikeCommentFeedbackMicroservice.Repositories.Interfaces;
using LikeCommentFeedbackMicroservice.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LikeCommentFeedbackMicroservice.Services
{
    public class LikeService : ILikeService
    {
        private readonly IBaseRepository<Like> _likeRepository;
        private readonly IMapper _mapper;

        public LikeService(
            IBaseRepository<Like> likeRepository,
            IMapper mapper)
        {
            _likeRepository = likeRepository;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ReadLikeDto> AddLikeAsync(CreateLikeDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto), "DTO cannot be null");
            }

            var like = _mapper.Map<Like>(dto);
            await _likeRepository.CreateAsync(like);
            return _mapper.Map<ReadLikeDto>(like);
        }

        [HttpGet]
        public async Task<IEnumerable<ReadLikeDto>> GetLikesByReviewIdAsync(int reviewId)
        {
            var likes = await _likeRepository.GetAll()
                                             .Where(l => l.ReviewId == reviewId)
                                             .ToListAsync();

            return _mapper.Map<IEnumerable<ReadLikeDto>>(likes);
        }

        [HttpDelete]
        public async Task RemoveLikeAsync(int likeId)
        {
            var like = await _likeRepository.GetAll()
                                        .FirstOrDefaultAsync(l => l.Id == likeId);
            if (like == null)
            {
                throw new KeyNotFoundException($"Like with ID {likeId} not found");
            }

            await _likeRepository.RemoveAsync(like);
        }

        [HttpGet]
        public async Task<ReadLikeDto> GetLikeByIdAsync(int likeId)
        {
            var like = await _likeRepository.GetAll().FirstOrDefaultAsync(l => l.Id == likeId);
            if (like == null)
            {
                throw new KeyNotFoundException($"Like with ID {likeId} not found");
            }

            return _mapper.Map<ReadLikeDto>(like);
        }
    }
}
