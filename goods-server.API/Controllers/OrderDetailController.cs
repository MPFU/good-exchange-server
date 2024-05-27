using goods_server.Contracts;
using goods_server.Service.InterfaceService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace goods_server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;

        public OrderDetailController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        // GET: api/OrderDetail/orderId/productId
        [HttpGet("{orderId}/{productId}")]
        public async Task<IActionResult> GetOrderDetail(int orderId, int productId)
        {
            var orderDetail = await _orderDetailService.GetOrderDetailAsync(orderId, productId);
            if (orderDetail == null)
            {
                return NotFound();
            }
            return Ok(orderDetail);
        }

        // GET: api/OrderDetail/orderId
        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrderDetailsByOrderId(int orderId)
        {
            var orderDetails = await _orderDetailService.GetOrderDetailsByOrderIdAsync(orderId);
            if (orderDetails == null)
            {
                return NotFound();
            }
            return Ok(orderDetails);
        }

        // POST: api/OrderDetail
        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail([FromBody] OrderDetailDTO orderDetailDTO)
        {
            if (orderDetailDTO == null)
            {
                return BadRequest("Order detail data is null.");
            }

            var result = await _orderDetailService.CreateOrderDetailAsync(orderDetailDTO);
            if (!result)
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return CreatedAtAction(nameof(GetOrderDetail), new { orderId = orderDetailDTO.OrderId, productId = orderDetailDTO.ProductId }, orderDetailDTO);
        }

        // PUT: api/OrderDetail/orderId/productId
        [HttpPut("{orderId}/{productId}")]
        public async Task<IActionResult> UpdateOrderDetail(int orderId, int productId, [FromBody] OrderDetailDTO orderDetailDTO)
        {
            if (orderDetailDTO == null)
            {
                return BadRequest("Order detail data is null.");
            }

            var result = await _orderDetailService.UpdateOrderDetailAsync(orderId, productId, orderDetailDTO);
            if (!result)
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return NoContent();
        }

        // DELETE: api/OrderDetail/orderId/productId
        [HttpDelete("{orderId}/{productId}")]
        public async Task<IActionResult> DeleteOrderDetail(int orderId, int productId)
        {
            var result = await _orderDetailService.DeleteOrderDetailAsync(orderId, productId);
            if (!result)
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return NoContent();
        }
    }
}
