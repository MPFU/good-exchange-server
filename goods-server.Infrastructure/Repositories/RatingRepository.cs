using goods_server.Core.InterfacesRepo;
using goods_server.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goods_server.Infrastructure.Repositories
{
    public class RatingRepository : GenericRepository<Rating>, IRatingRepo
    {
        public RatingRepository(GoodsExchangeApplication2024DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Rating?> GetRatingByIdAsync(int id)
        {
            return await _dbContext.Ratings.FindAsync(id);
        }

        public async Task<IEnumerable<Rating>> GetRatingsByProductIdAsync(int productId)
        {
            return await _dbContext.Ratings.Where(r => r.ProductId == productId).ToListAsync();
        }
    }
}
