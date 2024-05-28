﻿using goods_server.Core.InterfacesRepo;
using goods_server.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goods_server.Infrastructure.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepo
    {
        public OrderRepository(GoodsExchangeApplication2024DbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(int customerId)
        {
            return await _dbContext.Orders.Where(x => x.CustomerId == customerId).ToListAsync();
        }

        public async Task<bool> UpdateOrderAsync(int orderId, Order order)
        {
            var existingOrder = await _dbContext.Orders.FindAsync(orderId);
            if (existingOrder == null)
            {
                return false;
            }

            existingOrder.Status = order.Status;
            _dbContext.Orders.Update(existingOrder);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteOrderAsync(int orderId)
        {
            var order = await _dbContext.Orders.FindAsync(orderId);
            if (order == null)
            {
                return false;
            }

            _dbContext.Orders.Remove(order);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }

}
