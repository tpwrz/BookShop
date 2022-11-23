using AutoMapper;
using BookShop.Domain.Models;
using BookShop.Dtos;

internal class BookMappingProfile : Profile
{
    public BookMappingProfile()
    {
        CreateMap<Book, BookDto>();
    }
}