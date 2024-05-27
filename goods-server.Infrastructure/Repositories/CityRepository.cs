﻿using goods_server.Core.InterfacesRepo;
using goods_server.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace goods_server.Infrastructure.Repositories
{
    public class CityRepository : GenericRepository<City>, ICityRepo
    {
        public CityRepository(GoodsExchangeApplication2024DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<City?> GetCityByNameAsync(string name)
        {
            return await _dbContext.Cities.FirstOrDefaultAsync(c => c.Name == name);
        }
    }
}
