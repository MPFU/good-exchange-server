using goods_server.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace goods_server.Service.InterfaceService
{
    public interface ICityService
    {
        Task<GetCityDTO?> GetCityByIdAsync(int cityId);
        Task<IEnumerable<GetCityDTO>> GetAllCitiesAsync();
        Task<bool> CreateCityAsync(CreateCityDTO cityDTO);
        Task<bool> UpdateCityAsync(int cityId, UpdateCityDTO cityDTO);
        Task<bool> DeleteCityAsync(int cityId);
    }
}
