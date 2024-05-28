using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goods_server.Contracts
{
    public class ReportDTO
    {
        public int? AccountId { get; set; }
        public int? ProductId { get; set; }
        public string? Descript { get; set; }
        public string? Status { get; set; }
    }

    public class UpdateReportDTO : ReportDTO
    {
        public int ReportId { get; set; }
    }

}
