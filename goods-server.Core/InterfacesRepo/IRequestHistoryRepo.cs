using goods_server.Core.Interfaces;
using goods_server.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goods_server.Core.InterfacesRepo
{
    public interface IRequestHistoryRepo : IGenericRepo<RequestHistory>
    {
        Task<IEnumerable<RequestHistory>> GetRequestHistoriesByAccountIdAsync(int accountId);
        Task<bool> UpdateRequestHistoryAsync(int requestId, RequestHistory requestHistory);
        Task<bool> DeleteRequestHistoryAsync(int requestId);
    }
}
