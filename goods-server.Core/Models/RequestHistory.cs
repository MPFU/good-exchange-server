using System;
using System.Collections.Generic;

namespace goods_server.Core.Models;

public partial class RequestHistory
{
    public int Id { get; set; }

    public int? BuyerId { get; set; }

    public int? SellerId { get; set; }

    public int? ProductSellerId { get; set; }

    public int? ProductBuyerId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? Status { get; set; }

    public virtual Account? Buyer { get; set; }

    public virtual Product? ProductBuyer { get; set; }

    public virtual Product? ProductSeller { get; set; }

    public virtual Account? Seller { get; set; }
}
