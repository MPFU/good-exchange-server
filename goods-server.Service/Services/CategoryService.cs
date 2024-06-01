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

        public async Task<GetCategoryDTO?> GetCategoryByNameAsync(string name)
        {
            try
            {
                var category = await _unitOfWork.CategoryRepo.GetCategoryByNameAsync(name);
                return _mapper.Map<GetCategoryDTO>(category);
            }
            catch (Exception ex)
            {
                // Log the exception (if logging is configured)
                // Log.Error(ex, "An error occurred while getting category by name");
                throw new ApplicationException("An error occurred while getting category by name", ex);
            }
        }

        public async Task<GetCategoryDTO?> GetCategoryByIdAsync(int categoryId)
        {
            try
            {
                var category = await _unitOfWork.CategoryRepo.GetByIdAsync(categoryId);
                return _mapper.Map<GetCategoryDTO>(category);
            }
            catch (Exception ex)
            {
                // Log the exception (if logging is configured)
                // Log.Error(ex, "An error occurred while getting category by ID");
                throw new ApplicationException("An error occurred while getting category by ID", ex);
            }
        }

        public async Task<IEnumerable<GetCategoryDTO>> GetAllCategoriesAsync()
        {
            try
            {
                var categories = await _unitOfWork.CategoryRepo.GetAllAsync();
                return _mapper.Map<IEnumerable<GetCategoryDTO>>(categories);
            }
            catch (Exception ex)
            {
                // Log the exception (if logging is configured)
                // Log.Error(ex, "An error occurred while getting all categories");
                throw new ApplicationException("An error occurred while getting all categories", ex);
            }
        }

        public async Task<bool> CreateCategoryAsync(CreateCategoryDTO categoryDTO)
        {
            try
            {
                var category = _mapper.Map<Category>(categoryDTO);
                await _unitOfWork.CategoryRepo.AddAsync(category);
                return await _unitOfWork.SaveAsync() > 0;
            }
            catch (Exception ex)
            {
                // Log the exception (if logging is configured)
                // Log.Error(ex, "An error occurred while creating category");
                throw new ApplicationException("An error occurred while creating category", ex);
            }
        }

        public async Task<bool> UpdateCategoryAsync(int categoryId, UpdateCategoryDTO categoryDTO)
        {
            try
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
            catch (Exception ex)
            {
                // Log the exception (if logging is configured)
                // Log.Error(ex, "An error occurred while updating category");
                throw new ApplicationException("An error occurred while updating category", ex);
            }
        }

        public async Task<bool> DeleteCategoryAsync(int categoryId)
        {
            try
            {
                var category = await _unitOfWork.CategoryRepo.GetByIdAsync(categoryId);
                if (category == null)
                {
                    return false;
                }

                _unitOfWork.CategoryRepo.Delete(category);
                return await _unitOfWork.SaveAsync() > 0;
            }
            catch (Exception ex)
            {
                // Log the exception (if logging is configured)
                // Log.Error(ex, "An error occurred while deleting category");
                throw new ApplicationException("An error occurred while deleting category", ex);
            }
        }
    }
}
