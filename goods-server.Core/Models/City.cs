using System;
using System.Collections.Generic;

namespace goods_server.Core.Models;

public partial class City
{
    public int CityId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
