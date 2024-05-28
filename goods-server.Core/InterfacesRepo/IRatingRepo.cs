﻿using goods_server.Core.Interfaces;
using goods_server.Core.Models;
using System.Threading.Tasks;

namespace goods_server.Core.InterfacesRepo
{
    public interface IRatingRepo : IGenericRepo<Rating>
    {
        Task<Rating?> GetRatingByIdAsync(int id);
        Task<IEnumerable<Rating>> GetRatingsByProductIdAsync(int productId);
    }
}
