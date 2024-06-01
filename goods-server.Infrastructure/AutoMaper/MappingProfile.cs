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
            CreateMap<UpdateProfileDTO, Account>();

            // Category
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();
            CreateMap<Category, GetCategoryDTO>().ReverseMap();

            // City
            CreateMap<City, CreateCityDTO>().ReverseMap();
            CreateMap<City, UpdateCityDTO>().ReverseMap();
            CreateMap<City, GetCityDTO>().ReverseMap();

            // OrderDetail
            CreateMap<OrderDetail, OrderDetailDTO>().ReverseMap();

            // Genre
            CreateMap<Genre, GenreDTO>().ReverseMap();

            // Rating
            CreateMap<Rating, RatingDTO>().ReverseMap();
        }
    }
}
