using BookShop.Application.Repositories;
using BookShop.Domain.Models;
using BookShop.Dtos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Services
{
    public class BookService : IBookService
    {

        private readonly IRepository<Book> _bookRepository;

        public BookService(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Book AddNewBook(CreateBookDto createBookDto)
        {
            if (CheckIfIdnpExists(createBookDto.Isbn))
                return null;

            var book = new Book
            {
                Isbn = createBookDto.Isbn,
                Title = createBookDto.Title,
                AuthorId = (int)createBookDto.AuthorId,
                GenreId = (int)createBookDto.GenreId,
                LanguageId = (int)createBookDto.LanguageId,
                ReleaseDate = (DateOnly)createBookDto.ReleaseDate,
                Price = createBookDto.Price,
                AvailabilityId = createBookDto.Available,
            };

            _bookRepository.Add(book);
            _bookRepository.Save();
            return book;
        }

        private bool CheckIfIdnpExists(string isbn)
        {
            throw new NotImplementedException();
        }

        public Book GetBookById(int id)
        {
            return _bookRepository.Find(id);
        }

        public IList<Book> GetBooks(FilterOptions filterOptions)
        {
            IQueryable<Book> books;

            if (!string.IsNullOrWhiteSpace(filterOptions.SearchTerm))
            {
                books = _bookRepository.FindAll(e => e.Title.Contains(filterOptions.SearchTerm));
            }
            else
            {
                books = _bookRepository.GetAll();
            }

            switch (filterOptions.Order)
            {
                case SortOrder.Ascending:
                    books = books.OrderBy(e => e.Title);
                    break;
                case SortOrder.Descending:
                    books = books.OrderByDescending(e => e.Title);
                    break;
            }

            return books.ToList();
        }

        public bool RemoveBookById(int id)
        {
            var book = _bookRepository.Find(id);
            if (book != null)
            {
                _bookRepository.Delete(book);
                _bookRepository.Save();
                return true;
            }
            else return false;
        }

        public Book UpdateBook(int id, CreateBookDto dto)
        {
            Book book = _bookRepository.Find(id);

            if (book == null)
            {
                throw new Exception("Employee not found!");

            }
            else if (dto.Isbn != book.Isbn && CheckIfIdnpExists(dto.Isbn))
                return null;

            book.Isbn = dto.Isbn;
            book.Title = dto.Title;
            book.AuthorId = (int)dto.AuthorId;
            book.GenreId = (int)dto.GenreId;
            book.LanguageId = (int)dto.LanguageId;
            book.ReleaseDate = (DateOnly)dto.ReleaseDate;
            book.Price = dto.Price;
            book.AvailabilityId = dto.Available;

            _bookRepository.Save();
            return book;
        }

        public Book UpdateBookDetails(int id, UpdateBookDto dto)
        {
            var book = _bookRepository.Find(id);
            if (book == null)
                return null;

            if (!string.IsNullOrWhiteSpace(dto.Title))
                book.Title = dto.Title;

            if (dto.AuthorId>0)
                book.AuthorId = dto.AuthorId;

            if ( book.Isbn != dto.Isbn)
            {
                if (CheckIfIdnpExists(dto.Isbn))
                {
                    throw new Exception("Another user with such IDNP already exists in the system!");
                }
                book.Isbn = dto.Isbn;
            }

            if (dto.Price >0)
            {
                book.Price = dto.Price;
            }

            _bookRepository.Save();
            return book;
        }

        private bool CheckIfIdnpExist(string isbn)
        {
            return _bookRepository.Find(x => x.Isbn == isbn) != null;
        }
    }
}
