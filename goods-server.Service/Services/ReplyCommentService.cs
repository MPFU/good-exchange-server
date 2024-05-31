using AutoMapper;
using goods_server.Contracts;
using goods_server.Core.InterfacesRepo;
using goods_server.Core.Models;
using goods_server.Service.InterfaceService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goods_server.Service.Services
{
    public class ReplyCommentService:IReplyCommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReplyCommentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateReplyCommentAsync(CreateReplyDTO replyDTO)
        {
            try
            {
                var reply = _mapper.Map<ReplyComment>(replyDTO);
                reply.PostDate = DateTime.UtcNow;
                await _unitOfWork.ReplyCommentRepo.AddAsync(reply);
                var result = await _unitOfWork.SaveAsync() > 0;
                return result;
            }catch(DbUpdateException)
            {
                throw;
            }
        }

        public async Task<bool> DeleteReplyCommentAsync(int id)
        {
            try
            {
                var reply = await _unitOfWork.ReplyCommentRepo.GetByIdAsync(id);
                if (reply != null)
                {
                    _unitOfWork.ReplyCommentRepo.Delete(reply);
                   var result = await _unitOfWork.SaveAsync() > 0;
                    return result;
                }
                return false;
            }catch(DbUpdateException)
            {
                throw;
            }
        }

        public async Task<bool> UpdateReplyCommentAsync(int id, UpdateReplyCommentDTO replyDTO)
        {
            try
            {
                var reply = await _unitOfWork.ReplyCommentRepo.GetByIdAsync(id);
                if (reply != null)
                {
                    reply.Descript = replyDTO.Descript;
                    _unitOfWork.ReplyCommentRepo.Update(reply);
                    var result = await _unitOfWork.SaveAsync() > 0;
                    return result;
                }
                return false;
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

       
    }
}
