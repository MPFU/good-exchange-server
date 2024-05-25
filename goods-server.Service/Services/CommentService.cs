using AutoMapper;
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
   public class CommentService : ICommentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
        private object comment;
        private object comments;

        public CommentService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> CreateCommentAsync(CommentDTO commentDto)
    {
        var comment = _mapper.Map<Comment>(commentDto);
        comment.CreatedAt = DateTime.UtcNow;
        await _unitOfWork.CommentRepo.AddAsync(comment);
        var result = await _unitOfWork.SaveAsync() > 0;
        return result;
    }

    public async Task<IEnumerable<CommentDTO>> GetCommentsByAccountIdAsync(int accountId)
    {
            _unitOfWork.CommentRepo.AddAsync(comment);

            return _mapper.Map<IEnumerable<CommentDTO>>(comments);
    }
}

}
