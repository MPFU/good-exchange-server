using AutoMapper;
using goods_server.Contracts;
using goods_server.Core.Models;

namespace goods_server.Infrastructure.AutoMaper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Account
            CreateMap<Account, AccountDTO>().ReverseMap();
            CreateMap<Account, GetAccountDTO>().ReverseMap();
            CreateMap<RegisterDTO, Account>();
            // Category
            CreateMap<Category, CategoryDTO>().ReverseMap();
            // City
            CreateMap<City, CityDTO>().ReverseMap();
            // OrderDetail
            CreateMap<OrderDetail, OrderDetailDTO>().ReverseMap();
            // Genre
            CreateMap<Genre, GenreDTO>().ReverseMap();
            // Rating
            CreateMap<Rating, RatingDTO>().ReverseMap();
        }
    }
}
