using goods_server.Core.Interfaces;
using goods_server.Core.Models;
using System.Threading.Tasks;

namespace goods_server.Core.InterfacesRepo
{
    public interface IOrderDetailRepo : IGenericRepo<OrderDetail>
    {
        Task<OrderDetail?> GetOrderDetailAsync(int orderId, int productId);
    }
}
