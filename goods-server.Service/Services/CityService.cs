using AutoMapper;
using goods_server.Contracts;
using goods_server.Core.InterfacesRepo;
using goods_server.Core.Models;
using goods_server.Service.InterfaceService;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<GetCityDTO?> GetCityByIdAsync(int cityId)
        {
            try
            {
                var city = await _unitOfWork.CityRepo.GetByIdAsync(cityId);
                return _mapper.Map<GetCityDTO>(city);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while getting city by ID", ex);
            }
        }

        public async Task<IEnumerable<GetCityDTO>> GetAllCitiesAsync()
        {
            try
            {
                var cities = await _unitOfWork.CityRepo.GetAllAsync();
                return _mapper.Map<IEnumerable<GetCityDTO>>(cities);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while getting all cities", ex);
            }
        }

        public async Task<bool> CreateCityAsync(CreateCityDTO cityDTO)
        {
            try
            {
                var city = _mapper.Map<City>(cityDTO);
                await _unitOfWork.CityRepo.AddAsync(city);
                return await _unitOfWork.SaveAsync() > 0;
            }
            catch (DbUpdateException ex)
            {
                throw new ApplicationException("An error occurred while creating city", ex);
            }
        }

        public async Task<bool> UpdateCityAsync(int cityId, UpdateCityDTO cityDTO)
        {
            try
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
            catch (DbUpdateException ex)
            {
                throw new ApplicationException("An error occurred while updating city", ex);
            }
        }

        public async Task<bool> DeleteCityAsync(int cityId)
        {
            try
            {
                var city = await _unitOfWork.CityRepo.GetByIdAsync(cityId);
                if (city == null)
                {
                    return false;
                }

                _unitOfWork.CityRepo.Delete(city);
                return await _unitOfWork.SaveAsync() > 0;
            }
            catch (DbUpdateException ex)
            {
                throw new ApplicationException("An error occurred while deleting city", ex);
            }
        }
    }
}
