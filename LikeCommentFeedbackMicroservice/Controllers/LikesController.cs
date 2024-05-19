using LikeCommentFeedbackMicroservice.DTOs.Like;
using LikeCommentFeedbackMicroservice.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LikeCommentFeedbackMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        private readonly ILikeService _likeService;

        public LikesController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpPost("AddLike")]
        public async Task<ActionResult<ReadLikeDto>> AddLike([FromBody] CreateLikeDto createLikeDto)
        {
            if (createLikeDto == null)
            {
                return BadRequest("Invalid data.");
            }

            var createdLike = await _likeService.AddLikeAsync(createLikeDto);
            return CreatedAtAction(nameof(GetLikeById), new { id = createdLike.Id }, createdLike);
        }

        [HttpGet("GetLikesByReviewId")]
        public async Task<ActionResult<IEnumerable<ReadLikeDto>>> GetLikesByReviewId(int reviewId)
        {
            var likes = await _likeService.GetLikesByReviewIdAsync(reviewId);
            if (likes == null)
            {
                return NotFound();
            }

            return Ok(likes);
        }

        [HttpDelete("RemoveLike")]
        public async Task<IActionResult> RemoveLike(int id)
        {
            try
            {
                await _likeService.RemoveLikeAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet("GetLikeById")]
        public async Task<ActionResult<ReadLikeDto>> GetLikeById(int id)
        {
            var like = await _likeService.GetLikeByIdAsync(id);
            if (like == null)
            {
                return NotFound();
            }

            return Ok(like);
        }
    }
}
