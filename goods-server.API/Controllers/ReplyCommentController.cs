using artshare_server.WebAPI.ResponseModels;
using goods_server.Contracts;
using goods_server.Service.InterfaceService;
using goods_server.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace goods_server.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReplyCommentController : ControllerBase
    {
        private readonly IReplyCommentService _replyCommentService;

        public ReplyCommentController(IReplyCommentService replyCommentService)
        {
            _replyCommentService = replyCommentService;
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetReplyCommentByCommentId(int id)
        {
            try
            {
                var reply = await _replyCommentService.GetReplyCommentByCommentIdAsync(id);
                if (reply == null)
                {
                    return NotFound();
                }
                return Ok(reply);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetReplyCommentByCommenter(int id)
        {
            try
            {
                var reply = await _replyCommentService.GetReplyCommentByCommenterIdAsync(id);
                if (reply == null)
                {
                    return NotFound();
                }
                return Ok(reply);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetReplyCommentById(int id)
        {
            try
            {
                var reply = await _replyCommentService.GetReplyCommentByIdAsync(id);
                if (reply == null)
                {
                    return NotFound();
                }
                return Ok(reply);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateReplyComment([FromBody] CreateReplyDTO createReply)
        {
            try
            {
                var reply = await _replyCommentService.CreateReplyCommentAsync(createReply);
                if (!reply)
                {
                    return StatusCode(500, new FailedResponseModel
                    {
                        Status = 500,
                        Message = "Create Reply Comment failed."
                    });
                }
                return Ok(new SucceededResponseModel()
                {
                    Status = Ok().StatusCode,
                    Message = "Success",
                    Data = new
                    {
                        Reply = await _replyCommentService.GetReplyCommentByCommenterIdAsync((int)createReply.CommenterId)
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

        [HttpPut("id")]
        public async Task<IActionResult> EditReplyCommentAsync(int id,UpdateReplyCommentDTO updateReplyComment)
        {
            try
            {
                var reply = await _replyCommentService.UpdateReplyCommentAsync(id, updateReplyComment);
                if (!reply)
                {
                    return StatusCode(500, new FailedResponseModel
                    {
                        Status = 500,
                        Message = "Edit Reply Comment failed."
                    });
                }
                return Ok(new SucceededResponseModel()
                {
                    Status = Ok().StatusCode,
                    Message = "Success",
                    Data = new
                    {
                        Reply = await _replyCommentService.GetReplyCommentByIdAsync(id)
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

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteReplyComment(int id)
        {
            try
            {
                var reply = await _replyCommentService.DeleteReplyCommentAsync(id);
                if (!reply)
                {
                    return StatusCode(500, new FailedResponseModel
                    {
                        Status = 500,
                        Message = "Delete Reply Comment failed."
                    });
                }
                return Ok(new SucceededResponseModel()
                {
                    Status = Ok().StatusCode,
                    Message = "Success",
                    Data = new
                    {
                        Reply = await _replyCommentService.GetReplyCommentByIdAsync(id)
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
    }
}
