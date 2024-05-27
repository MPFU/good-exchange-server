using AutoMapper;
using goods_server.Contracts;
using goods_server.Core.InterfacesRepo;
using goods_server.Core.Models;
using goods_server.Service.InterfaceService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace goods_server.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CategoryDTO?> GetCategoryByNameAsync(string name)
        {
            var category = await _unitOfWork.CategoryRepo.GetCategoryByNameAsync(name);
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task<CategoryDTO?> GetCategoryByIdAsync(int categoryId)
        {
            var category = await _unitOfWork.CategoryRepo.GetByIdAsync(categoryId);
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync()
        {
            var categories = await _unitOfWork.CategoryRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        public async Task<bool> CreateCategoryAsync(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);
            await _unitOfWork.CategoryRepo.AddAsync(category);
            return await _unitOfWork.SaveAsync() > 0;
        }

        public async Task<bool> UpdateCategoryAsync(int categoryId, CategoryDTO categoryDTO)
        {
            var category = await _unitOfWork.CategoryRepo.GetByIdAsync(categoryId);
            if (category == null)
            {
                return false;
            }

            category.Name = categoryDTO.Name;
            _unitOfWork.CategoryRepo.Update(category);
            return await _unitOfWork.SaveAsync() > 0;
        }

        public async Task<bool> DeleteCategoryAsync(int categoryId)
        {
            var category = await _unitOfWork.CategoryRepo.GetByIdAsync(categoryId);
            if (category == null)
            {
                return false;
            }

            _unitOfWork.CategoryRepo.Delete(category);
            return await _unitOfWork.SaveAsync() > 0;
        }
    }
}
