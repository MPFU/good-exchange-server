﻿using AutoMapper;
using goods_server.Contracts;
using goods_server.Core.InterfacesRepo;
using goods_server.Core.Models;
using goods_server.Service.InterfaceService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goods_server.Service.Services
{
    public class ReportService : IReportService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReportService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateReportAsync(ReportDTO reportDto)
        {
            var report = _mapper.Map<Report>(reportDto);
            report.PostDate = DateTime.UtcNow;
            await _unitOfWork.ReportRepo.AddAsync(report);
            var result = await _unitOfWork.SaveAsync() > 0;
            return result;
        }

        public async Task<IEnumerable<ReportDTO>> GetReportsByAccountIdAsync(int accountId)
        {
            var reports = await _unitOfWork.ReportRepo.GetReportsByAccountIdAsync(accountId);
            return _mapper.Map<IEnumerable<ReportDTO>>(reports);
        }

        public async Task<bool> UpdateReportAsync(int reportId, ReportDTO reportDto)
        {
            var report = _mapper.Map<Report>(reportDto);
            return await _unitOfWork.ReportRepo.UpdateReportAsync(reportId, report);
        }

        public async Task<bool> DeleteReportAsync(int reportId)
        {
            return await _unitOfWork.ReportRepo.DeleteReportAsync(reportId);
        }
    }

}
