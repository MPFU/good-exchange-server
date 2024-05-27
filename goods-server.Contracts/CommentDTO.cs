using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goods_server.Contracts
{
    public class CommentDTO
    {
        public int? CommenterId { get; set; }
        public int? ProductId { get; set; }
        public string? Descript { get; set; }
    }

    public class UpdateCommentDTO : CommentDTO
    {
        public int CommentId { get; set; }
    }

}
