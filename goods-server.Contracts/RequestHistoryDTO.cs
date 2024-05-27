using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goods_server.Contracts
{
    public class RequestHistoryDTO
    {
        public int? BuyerId { get; set; }
        public int? SellerId { get; set; }
        public int? ProductSellerId { get; set; }
        public int? ProductBuyerId { get; set; }
        public string? Status { get; set; }
    }

    public class UpdateRequestHistoryDTO : RequestHistoryDTO
    {
        public int Id { get; set; }
    }

}
