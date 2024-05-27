using AutoMapper;
using goods_server.Contracts;
using goods_server.Core.InterfacesRepo;
using goods_server.Core.Models;
using goods_server.Service.InterfaceService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace goods_server.Service.Services
{
    public class CityService : ICityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CityService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CityDTO?> GetCityByNameAsync(string name)
        {
            var city = await _unitOfWork.CityRepo.GetCityByNameAsync(name);
            return _mapper.Map<CityDTO>(city);
        }

        public async Task<CityDTO?> GetCityByIdAsync(int cityId)
        {
            var city = await _unitOfWork.CityRepo.GetByIdAsync(cityId);
            return _mapper.Map<CityDTO>(city);
        }

        public async Task<IEnumerable<CityDTO>> GetAllCitiesAsync()
        {
            var cities = await _unitOfWork.CityRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<CityDTO>>(cities);
        }

        public async Task<bool> CreateCityAsync(CityDTO cityDTO)
        {
            var city = _mapper.Map<City>(cityDTO);
            await _unitOfWork.CityRepo.AddAsync(city);
            return await _unitOfWork.SaveAsync() > 0;
        }

        public async Task<bool> UpdateCityAsync(int cityId, CityDTO cityDTO)
        {
            var city = await _unitOfWork.CityRepo.GetByIdAsync(cityId);
            if (city == null)
            {
                return false;
            }

            city.Name = cityDTO.Name;
            _unitOfWork.CityRepo.Update(city);
            return await _unitOfWork.SaveAsync() > 0;
        }

        public async Task<bool> DeleteCityAsync(int cityId)
        {
            var city = await _unitOfWork.CityRepo.GetByIdAsync(cityId);
            if (city == null)
            {
                return false;
            }

            _unitOfWork.CityRepo.Delete(city);
            return await _unitOfWork.SaveAsync() > 0;
        }
    }
}
