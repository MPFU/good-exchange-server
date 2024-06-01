﻿using AutoMapper;
using goods_server.Contracts;
using goods_server.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goods_server.Infrastructure.AutoMaper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            // ACCOUNT
            CreateMap<Account, AccountDTO>().ReverseMap();
            CreateMap<Account, GetAccountDTO>().ReverseMap();
            CreateMap<RegisterDTO, Account>();

            // REPLYCOMMENT
            CreateMap<CreateReplyDTO, ReplyComment>();
            CreateMap<ReplyComment, GetReplyCommentDTO>().ReverseMap();
        }
    }
}
