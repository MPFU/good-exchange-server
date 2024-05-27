﻿using goods_server.Core.Interfaces;
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

        public async Task<IEnumerable<Comment>> GetCommentsByAccountIdAsync(int accountId)
        {
            return await _dbContext.Comments.Where(x => x.CommenterId == accountId).ToListAsync();
        }

        public async Task<bool> UpdateCommentAsync(int commentId, Comment comment)
        {
            var existingComment = await _dbContext.Comments.FindAsync(commentId);
            if (existingComment == null)
            {
                return false;
            }

            existingComment.Descript = comment.Descript;
            _dbContext.Comments.Update(existingComment);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCommentAsync(int commentId)
        {
            var comment = await _dbContext.Comments.FindAsync(commentId);
            if (comment == null)
            {
                return false;
            }

            _dbContext.Comments.Remove(comment);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }




}
