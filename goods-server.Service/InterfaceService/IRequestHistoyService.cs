using goods_server.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goods_server.Service.InterfaceService
{
    public interface IRequestHistoyService
    {
        Task<bool> CreateRequestHistoryAsync(RequestHistoryDTO requestHistory);
        Task<IEnumerable<RequestHistoryDTO>> GetRequestHistoriesByAccountIdAsync(int accountId);
        Task<bool> UpdateRequestHistoryAsync(int requestId, RequestHistoryDTO requestHistory);
        Task<bool> DeleteRequestHistoryAsync(int requestId);

    }
}
