using goods_server.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace goods_server.Service.InterfaceService
{
    public interface ICategoryService
    {
        Task<CategoryDTO?> GetCategoryByNameAsync(string name);
        Task<CategoryDTO?> GetCategoryByIdAsync(int categoryId);
        Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync();
        Task<bool> CreateCategoryAsync(CategoryDTO categoryDTO);
        Task<bool> UpdateCategoryAsync(int categoryId, CategoryDTO categoryDTO);
        Task<bool> DeleteCategoryAsync(int categoryId);
    }
}
