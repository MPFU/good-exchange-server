using System;
using System.Collections.Generic;

namespace goods_server.Core.Models;

public partial class Rating
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public int? ProductId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? Descript { get; set; }

    public int? Rated { get; set; }

    public virtual Account? Customer { get; set; }

    public virtual Product? Product { get; set; }
}
