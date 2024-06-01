using goods_server.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goods_server.Service.InterfaceService
{
    public interface IReplyCommentService
    {
        Task<bool> CreateReplyCommentAsync(CreateReplyDTO replyDTO);
        Task<bool> UpdateReplyCommentAsync(int id, UpdateReplyCommentDTO replyDTO);
        Task<bool> DeleteReplyCommentAsync(int id);
        Task<GetReplyCommentDTO?> GetReplyCommentByCommentIdAsync(int id);
        Task<GetReplyCommentDTO?> GetReplyCommentByCommenterIdAsync(int id);
        Task<GetReplyCommentDTO?> GetReplyCommentByIdAsync(int id);
    }
}
