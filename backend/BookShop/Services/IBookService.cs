using BookShop.Domain.Models;
using BookShop.Dtos;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Services
{
    public interface IBookService
    {
        IList<Book> GetBooks(FilterOptions options);

        Book GetBookById(int id);

        Book AddNewBook(CreateBookDto dto);

        Book UpdateBookDetails(int id, UpdateBookDto dto);

        Book UpdateBook(int id, CreateBookDto dto);

        bool RemoveBookById(int id);
    }
}
