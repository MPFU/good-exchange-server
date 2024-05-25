﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goods_server.Service.InterfaceService
{
    public interface ICommentService
    {
        Task<bool> CreateCommentAsync(CommentDTO comment);
        Task<IEnumerable<CommentDTO>> GetCommentsByAccountIdAsync(int accountId);
    }

}
