using LikeCommentFeedbackMicroservice.DTOs.Comment;
using LikeCommentFeedbackMicroservice.DTOs.Review;
using LikeCommentFeedbackMicroservice.Services;
using LikeCommentFeedbackMicroservice.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LikeCommentFeedbackMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost("createReview")]
        public async Task<ActionResult<ReadReviewDto>> CreateReview([FromBody] CreateReviewDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid review data.");
            }

            var createdReview = await _reviewService.CreateReviewAsync(dto);
            return CreatedAtAction(nameof(GetReviewById), new { id = createdReview.Id }, createdReview);
        }

        [HttpDelete("deleteReview/{id}")]
        public async Task<ActionResult<ReadReviewDto>> DeleteReview(int id)
        {
            var deletedReview = await _reviewService.DeleteReviewAsync(id);
            if (deletedReview == null)
            {
                return NotFound();
            }

            return Ok(deletedReview);
        }

        [HttpGet("getReviews")]
        public async Task<ActionResult<IEnumerable<ReadReviewDto>>> GetReviews()
        {
            var reviews = await _reviewService.GetReviewsAsync();
            return Ok(reviews);
        }

        [HttpGet("getReviewsByProductId/{productId}")]
        public async Task<ActionResult<IEnumerable<ReadReviewDto>>> GetReviewsByProduct(int productId)
        {
            var reviews = await _reviewService.GetReviewsByProductAsync(productId);
            return Ok(reviews);
        }

        [HttpPut("updateReview")]
        public async Task<ActionResult<ReadReviewDto>> UpdateReview([FromBody] UpdateReviewDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid review data.");
            }

            var updatedReview = await _reviewService.UpdateReviewAsync(dto);
            if (updatedReview == null)
            {
                return NotFound();
            }

            return Ok(updatedReview);
        }

        [HttpGet("getReviewById/{id}")]
        public async Task<ActionResult<ReadReviewDto>> GetReviewById(int id)
        {
            var review = await _reviewService.GetReviewByIdAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            return Ok(review);
        }
    }
}
