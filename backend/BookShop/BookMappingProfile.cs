using AutoMapper;
using BookShop.Domain.Models;
using BookShop.Dtos;

public class BookMappingProfile : Profile
{
    public BookMappingProfile()
    {
        CreateMap<Book, BookDto>();
    }
}