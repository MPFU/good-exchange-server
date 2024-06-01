using goods_server.Core.Interfaces;
using goods_server.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goods_server.Core.InterfacesRepo
{
    public interface IReplyCommentRepo : IGenericRepo<ReplyComment>
    {
        public Task<ReplyComment?> GetReplyCommentByCommentIDAsync(int id);
        public Task<ReplyComment?> GetReplyCommentByCommenterAsync(int id);
    }
}
