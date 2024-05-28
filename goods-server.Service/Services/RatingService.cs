using AutoMapper;
using goods_server.Contracts;
using goods_server.Core.InterfacesRepo;
using goods_server.Core.Models;
using goods_server.Service.InterfaceService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace goods_server.Service.Services
{
    public class RatingService : IRatingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RatingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<RatingDTO?> GetRatingByIdAsync(int id)
        {
            var rating = await _unitOfWork.RatingRepo.GetRatingByIdAsync(id);
            return _mapper.Map<RatingDTO>(rating);
        }

        public async Task<IEnumerable<RatingDTO>> GetRatingsByProductIdAsync(int productId)
        {
            var ratings = await _unitOfWork.RatingRepo.GetRatingsByProductIdAsync(productId);
            return _mapper.Map<IEnumerable<RatingDTO>>(ratings);
        }

        public async Task<bool> CreateRatingAsync(RatingDTO ratingDTO)
        {
            var rating = _mapper.Map<Rating>(ratingDTO);
            await _unitOfWork.RatingRepo.AddAsync(rating);
            return await _unitOfWork.SaveAsync() > 0;
        }

        public async Task<bool> UpdateRatingAsync(int id, RatingDTO ratingDTO)
        {
            var rating = await _unitOfWork.RatingRepo.GetRatingByIdAsync(id);
            if (rating == null)
            {
                return false;
            }

            rating.CustomerId = ratingDTO.CustomerId;
            rating.ProductId = ratingDTO.ProductId;
            rating.CreatedDate = ratingDTO.CreatedDate;
            rating.Descript = ratingDTO.Descript;
            rating.Rated = ratingDTO.Rated;

            _unitOfWork.RatingRepo.Update(rating);
            return await _unitOfWork.SaveAsync() > 0;
        }

        public async Task<bool> DeleteRatingAsync(int id)
        {
            var rating = await _unitOfWork.RatingRepo.GetRatingByIdAsync(id);
            if (rating == null)
            {
                return false;
            }

            _unitOfWork.RatingRepo.Delete(rating);
            return await _unitOfWork.SaveAsync() > 0;
        }
    }
}
