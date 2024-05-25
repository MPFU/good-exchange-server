using artshare_server.WebAPI.ResponseModels;
using goods_server.Service.InterfaceService;
using Microsoft.AspNetCore.Mvc;

namespace goods_server.API.Controllers
{
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CommentDTO commentDto)
        {
            try
            {
                var result = await _commentService.CreateCommentAsync(commentDto);
                if (!result)
                {
                    return StatusCode(500, new FailedResponseModel
                    {
                        Status = 500,
                        Message = "Create comment failed."
                    });
                }
                return Ok(new SucceededResponseModel()
                {
                    Status = Ok().StatusCode,
                    Message = "Success",
                    Data = new
                    {
                        Comment = commentDto
                    }
                });
            }
            catch (Exception ex)
            {
                return Conflict(new FailedResponseModel()
                {
                    Status = Conflict().StatusCode,
                    Message = ex.Message
                });
            }
        }

        [HttpGet("{accountId}")]
        public async Task<IActionResult> GetCommentsByAccountId(int accountId)
        {
            try
            {
                var comments = await _commentService.GetCommentsByAccountIdAsync(accountId);
                if (comments == null)
                {
                    return NotFound();
                }
                return Ok(comments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
