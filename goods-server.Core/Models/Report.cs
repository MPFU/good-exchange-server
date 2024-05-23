using System;
using System.Collections.Generic;

namespace goods_server.Core.Models;

public partial class Report
{
    public int ReportId { get; set; }

    public int? AccountId { get; set; }

    public int? ProductId { get; set; }

    public DateTime? PostDate { get; set; }

    public string? Descript { get; set; }

    public string? Status { get; set; }

    public virtual Account? Account { get; set; }

    public virtual Product? Product { get; set; }
}
