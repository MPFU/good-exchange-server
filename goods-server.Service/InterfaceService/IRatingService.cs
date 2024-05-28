using goods_server.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace goods_server.Service.InterfaceService
{
    public interface IRatingService
    {
        Task<RatingDTO?> GetRatingByIdAsync(int id);
        Task<IEnumerable<RatingDTO>> GetRatingsByProductIdAsync(int productId);
        Task<bool> CreateRatingAsync(RatingDTO ratingDTO);
        Task<bool> UpdateRatingAsync(int id, RatingDTO ratingDTO);
        Task<bool> DeleteRatingAsync(int id);
    }
}
