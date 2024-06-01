﻿using goods_server.Core.InterfacesRepo;
using goods_server.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goods_server.Infrastructure.Repositories
{
    public class ReplyCommentRepository : GenericRepository<ReplyComment>,IReplyCommentRepo
    {
        public ReplyCommentRepository(GoodsExchangeApplication2024DbContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<ReplyComment?> GetReplyCommentByCommenterAsync(int id)
        {
            return await _dbContext.ReplyComments.Where(x => x.CommenterId == id).FirstOrDefaultAsync();
        }

        public async Task<ReplyComment?> GetReplyCommentByCommentIDAsync(int id)
        {
            return await _dbContext.ReplyComments.Where(x => x.CommentId == id).FirstOrDefaultAsync();
        }
    }
}
