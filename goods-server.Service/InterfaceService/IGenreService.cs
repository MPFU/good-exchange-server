using goods_server.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace goods_server.Service.InterfaceService
{
    public interface IGenreService
    {
        Task<GenreDTO?> GetGenreByNameAsync(string name);
        Task<GenreDTO?> GetGenreByIdAsync(int genreId);
        Task<IEnumerable<GenreDTO>> GetAllGenresAsync();
        Task<bool> CreateGenreAsync(GenreDTO genreDTO);
        Task<bool> UpdateGenreAsync(int genreId, GenreDTO genreDTO);
        Task<bool> DeleteGenreAsync(int genreId);
    }
}
