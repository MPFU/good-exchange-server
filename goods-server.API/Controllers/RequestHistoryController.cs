﻿using artshare_server.WebAPI.ResponseModels;
using goods_server.Contracts;
using goods_server.Service.InterfaceService;
using goods_server.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace goods_server.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RequestHistoryController : ControllerBase
    {
        private readonly IRequestHistoyService _requestHistoryService;

        public RequestHistoryController(IRequestHistoyService requestHistoryService)
        {
            _requestHistoryService = requestHistoryService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateRequestHistory([FromBody] RequestHistoryDTO requestHistoryDto)
        {
            try
            {
                var result = await _requestHistoryService.CreateRequestHistoryAsync(requestHistoryDto);
                if (!result)
                {
                    return StatusCode(500, new FailedResponseModel
                    {
                        Status = 500,
                        Message = "Create request history failed."
                    });
                }
                return Ok(new SucceededResponseModel()
                {
                    Status = Ok().StatusCode,
                    Message = "Success",
                    Data = new
                    {
                        RequestHistory = requestHistoryDto
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
        public async Task<IActionResult> GetRequestHistoriesByAccountId(int accountId)
        {
            try
            {
                var requestHistories = await _requestHistoryService.GetRequestHistoriesByAccountIdAsync(accountId);
                if (requestHistories == null)
                {
                    return NotFound();
                }
                return Ok(requestHistories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{requestId}")]
        public async Task<IActionResult> UpdateRequestHistory(int requestId, [FromBody] RequestHistoryDTO requestHistoryDto)
        {
            try
            {
                var result = await _requestHistoryService.UpdateRequestHistoryAsync(requestId, requestHistoryDto);
                if (!result)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{requestId}")]
        public async Task<IActionResult> DeleteRequestHistory(int requestId)
        {
            try
            {
                var result = await _requestHistoryService.DeleteRequestHistoryAsync(requestId);
                if (!result)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
