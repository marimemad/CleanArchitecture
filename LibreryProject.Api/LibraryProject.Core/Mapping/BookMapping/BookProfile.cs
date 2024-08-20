using AutoMapper;
using LibraryProject.Core.Features.BookFeature.Queries.Responses;
using LibraryProject.Data.Entities;

namespace LibraryProject.Core.Mapping.BookMapping
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            //queries
            CreateMap<Book, GetBookByIdResponce>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.LocalizeName(src.NameAr, src.NameEn)));

            CreateMap<Category, CategoryResponce>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.LocalizeName(src.NameAr, src.NameEn)));

            //CreateMap<Borrowing, BorrowingResponce>().ForMember(dest => dest.BorrowingUser, opt => opt.MapFrom(src => src.User.LocalizeName(src.User.NameAr, src.User.NameEn)));
            //commands

        }
    }
}
