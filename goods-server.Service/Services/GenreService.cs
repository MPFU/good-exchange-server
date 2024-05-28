using AutoMapper;
using goods_server.Contracts;
using goods_server.Core.InterfacesRepo;
using goods_server.Core.Models;
using goods_server.Service.InterfaceService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace goods_server.Service.Services
{
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GenreService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GenreDTO?> GetGenreByNameAsync(string name)
        {
            var genre = await _unitOfWork.GenreRepo.GetGenreByNameAsync(name);
            return _mapper.Map<GenreDTO>(genre);
        }

        public async Task<GenreDTO?> GetGenreByIdAsync(int genreId)
        {
            var genre = await _unitOfWork.GenreRepo.GetByIdAsync(genreId);
            return _mapper.Map<GenreDTO>(genre);
        }

        public async Task<IEnumerable<GenreDTO>> GetAllGenresAsync()
        {
            var genres = await _unitOfWork.GenreRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<GenreDTO>>(genres);
        }

        public async Task<bool> CreateGenreAsync(GenreDTO genreDTO)
        {
            var genre = _mapper.Map<Genre>(genreDTO);
            await _unitOfWork.GenreRepo.AddAsync(genre);
            return await _unitOfWork.SaveAsync() > 0;
        }

        public async Task<bool> UpdateGenreAsync(int genreId, GenreDTO genreDTO)
        {
            var genre = await _unitOfWork.GenreRepo.GetByIdAsync(genreId);
            if (genre == null)
            {
                return false;
            }

            genre.Name = genreDTO.Name;
            _unitOfWork.GenreRepo.Update(genre);
            return await _unitOfWork.SaveAsync() > 0;
        }

        public async Task<bool> DeleteGenreAsync(int genreId)
        {
            var genre = await _unitOfWork.GenreRepo.GetByIdAsync(genreId);
            if (genre == null)
            {
                return false;
            }

            _unitOfWork.GenreRepo.Delete(genre);
            return await _unitOfWork.SaveAsync() > 0;
        }
    }
}
