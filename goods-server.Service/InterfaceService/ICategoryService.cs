using goods_server.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace goods_server.Service.InterfaceService
{
    public interface ICategoryService
    {
        Task<GetCategoryDTO?> GetCategoryByNameAsync(string name);
        Task<GetCategoryDTO?> GetCategoryByIdAsync(int categoryId);
        Task<IEnumerable<GetCategoryDTO>> GetAllCategoriesAsync();
        Task<bool> CreateCategoryAsync(CreateCategoryDTO categoryDTO);
        Task<bool> UpdateCategoryAsync(int categoryId, UpdateCategoryDTO categoryDTO);
        Task<bool> DeleteCategoryAsync(int categoryId);
    }
}
