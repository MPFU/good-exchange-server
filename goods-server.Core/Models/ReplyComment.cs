using System;
using System.Collections.Generic;

namespace goods_server.Core.Models;

public partial class ReplyComment
{
    public int ReplyId { get; set; }

    public int? CommentId { get; set; }

    public int? CommenterId { get; set; }

    public string? Descript { get; set; }

    public DateTime? PostDate { get; set; }

    public virtual Comment? Comment { get; set; }

    public virtual Account? Commenter { get; set; }
}
