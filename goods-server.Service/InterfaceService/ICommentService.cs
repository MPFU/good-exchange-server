﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goods_server.Service.InterfaceService
{
    public interface ICommentService
    {
        Task<bool> CreateCommentAsync(Contracts.CommentDTO comment);
        Task<IEnumerable<Contracts.CommentDTO>> GetCommentsByAccountIdAsync(int accountId);
        Task<bool> UpdateCommentAsync(int commentId, Contracts.CommentDTO comment);
        Task<bool> DeleteCommentAsync(int commentId);
    }


}
