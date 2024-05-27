using goods_server.Core.Interfaces;
using goods_server.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goods_server.Core.InterfacesRepo
{
    public interface ICategoryRepo :IGenericRepo<Category>
    {
        Task<Category?> GetCategoryByNameAsync(string name);

    }
}
