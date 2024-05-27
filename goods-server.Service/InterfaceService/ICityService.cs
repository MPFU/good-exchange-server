using goods_server.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace goods_server.Service.InterfaceService
{
    public interface ICityService
    {
        Task<CityDTO?> GetCityByNameAsync(string name);
        Task<CityDTO?> GetCityByIdAsync(int cityId);
        Task<IEnumerable<CityDTO>> GetAllCitiesAsync();
        Task<bool> CreateCityAsync(CityDTO cityDTO);
        Task<bool> UpdateCityAsync(int cityId, CityDTO cityDTO);
        Task<bool> DeleteCityAsync(int cityId);
    }
}
