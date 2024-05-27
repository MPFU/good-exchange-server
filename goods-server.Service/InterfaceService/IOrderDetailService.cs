using goods_server.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace goods_server.Service.InterfaceService
{
    public interface IOrderDetailService
    {
        Task<OrderDetailDTO?> GetOrderDetailAsync(int orderId, int productId);
        Task<IEnumerable<OrderDetailDTO>> GetOrderDetailsByOrderIdAsync(int orderId);
        Task<bool> CreateOrderDetailAsync(OrderDetailDTO orderDetailDTO);
        Task<bool> UpdateOrderDetailAsync(int orderId, int productId, OrderDetailDTO orderDetailDTO);
        Task<bool> DeleteOrderDetailAsync(int orderId, int productId);
    }
}
