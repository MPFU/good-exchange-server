using goods_server.Core.Interfaces;
using goods_server.Core.Models;
using System.Threading.Tasks;

namespace goods_server.Core.InterfacesRepo
{
    public interface ICityRepo : IGenericRepo<City>
    {
        Task<City?> GetCityByNameAsync(string name);
    }
}
