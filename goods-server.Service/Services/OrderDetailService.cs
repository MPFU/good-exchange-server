using AutoMapper;
using goods_server.Contracts;
using goods_server.Core.InterfacesRepo;
using goods_server.Core.Models;
using goods_server.Service.InterfaceService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace goods_server.Service.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderDetailService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OrderDetailDTO?> GetOrderDetailAsync(int orderId, int productId)
        {
            var orderDetail = await _unitOfWork.OrderDetailRepo.GetOrderDetailAsync(orderId, productId);
            return _mapper.Map<OrderDetailDTO>(orderDetail);
        }

        public async Task<IEnumerable<OrderDetailDTO>> GetOrderDetailsByOrderIdAsync(int orderId)
        {
            var orderDetails = await _unitOfWork.OrderDetailRepo.GetAllAsync(od => od.OrderId == orderId);
            return _mapper.Map<IEnumerable<OrderDetailDTO>>(orderDetails);
        }

        public async Task<bool> CreateOrderDetailAsync(OrderDetailDTO orderDetailDTO)
        {
            var orderDetail = _mapper.Map<OrderDetail>(orderDetailDTO);
            await _unitOfWork.OrderDetailRepo.AddAsync(orderDetail);
            return await _unitOfWork.SaveAsync() > 0;
        }

        public async Task<bool> UpdateOrderDetailAsync(int orderId, int productId, OrderDetailDTO orderDetailDTO)
        {
            var orderDetail = await _unitOfWork.OrderDetailRepo.GetOrderDetailAsync(orderId, productId);
            if (orderDetail == null)
            {
                return false;
            }

            orderDetail.ProductName = orderDetailDTO.ProductName;
            orderDetail.Quantity = orderDetailDTO.Quantity;
            orderDetail.Price = orderDetailDTO.Price;
            _unitOfWork.OrderDetailRepo.Update(orderDetail);
            return await _unitOfWork.SaveAsync() > 0;
        }

        public async Task<bool> DeleteOrderDetailAsync(int orderId, int productId)
        {
            var orderDetail = await _unitOfWork.OrderDetailRepo.GetOrderDetailAsync(orderId, productId);
            if (orderDetail == null)
            {
                return false;
            }

            _unitOfWork.OrderDetailRepo.Delete(orderDetail);
            return await _unitOfWork.SaveAsync() > 0;
        }
    }
}
