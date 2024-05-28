﻿using goods_server.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goods_server.Service.InterfaceService
{
    public interface IReportService
{
    Task<bool> CreateReportAsync(ReportDTO report);
    Task<IEnumerable<ReportDTO>> GetReportsByAccountIdAsync(int accountId);
    Task<bool> UpdateReportAsync(int reportId, ReportDTO report);
    Task<bool> DeleteReportAsync(int reportId);
}

}
