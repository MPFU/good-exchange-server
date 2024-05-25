using goods_server.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goods_server.Core.InterfacesRepo
{
    public interface ICommentRepo
    {
        Task AddAsync(Comment comment);
        void AddAsync(object comment);
        Task GetCommentsByAccountIdAsync(int accountId);
        Task GetCommentsByAccountIdAsync<T>(int accountId);
    }
}
