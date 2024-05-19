using LikeCommentFeedbackMicroservice.DTOs.Comment;
using LikeCommentFeedbackMicroservice.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LikeCommentFeedbackMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost("createComment")]
        public async Task<ActionResult<ReadCommentDto>> CreateComment([FromBody] CreateCommentDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid comment data.");
            }

            var createdComment = await _commentService.CreateCommentAsync(dto);
            return CreatedAtAction(nameof(GetCommentById), new { id = createdComment.Id }, createdComment);
        }

        [HttpDelete("deleteComment")]
        public async Task<ActionResult<ReadCommentDto>> DeleteComment(int id)
        {
            var deletedComment = await _commentService.DeleteCommentAsync(id);
            if (deletedComment == null)
            {
                return NotFound();
            }

            return Ok(deletedComment);
        }

        [HttpGet("getComments")]
        public async Task<ActionResult<IEnumerable<ReadCommentDto>>> GetComments()
        {
            var comments = await _commentService.GetCommentsAsync();
            return Ok(comments);
        }

        [HttpGet("getCommentsByProductId")]
        public async Task<ActionResult<IEnumerable<ReadCommentDto>>> GetCommentsByProduct(int productId)
        {
            var comments = await _commentService.GetCommentsByProductAsync(productId);
            return Ok(comments);
        }

        [HttpPut("updateComment")]
        public async Task<ActionResult<ReadCommentDto>> UpdateComment([FromBody] UpdateCommentDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid comment data.");
            }

            var updatedComment = await _commentService.UpdateCommentAsync(dto);
            if (updatedComment == null)
            {
                return NotFound();
            }

            return Ok(updatedComment);
        }

        [HttpGet("getCommentById")]
        public async Task<ActionResult<ReadCommentDto>> GetCommentById(int id)
        {
            var comment = await _commentService.GetCommentByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }

    }
}
