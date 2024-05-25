using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goods_server.Contracts
{
    internal class CommentDTO
    {
        public string Content { get; set; }
        public int AccountId { get; set; }
    }
}
