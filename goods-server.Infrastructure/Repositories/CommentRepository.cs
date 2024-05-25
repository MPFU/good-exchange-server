using goods_server.Core.Interfaces;
using goods_server.Core.InterfacesRepo;
using goods_server.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goods_server.Infrastructure.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepo
    {
        public CommentRepository(GoodsExchangeApplication2024DbContext dbContext) : base(dbContext)
        {

        }

        public void AddAsync(object comment)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Comment>> GetCommentsByAccountIdAsync(int accountId)
        {
            return await _dbContext.Comments.Where(x => x.AccountId == accountId).ToListAsync();
        }

        public Task GetCommentsByAccountIdAsync<T>(int accountId)
        {
            throw new NotImplementedException();
        }

        Task ICommentRepo.GetCommentsByAccountIdAsync(int accountId)
        {
            throw new NotImplementedException();
        }
    }

}
