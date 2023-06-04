using AutoMapper;
using BookShop.Application.Repositories;
using BookShop.Domain.Models;
using BookShop.Dtos;
using BookShop.Infrastructure.Persistance.Extentions;
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
        private readonly IMapper _mapper;

        public BookService(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Book AddNewBook(CreateBookDto createBookDto)
        {
            if (CheckIfIsbnExists(createBookDto.Isbn))
                return null;

            var book = new Book
            {
                Isbn = createBookDto.Isbn,
                Title = createBookDto.Title,
                AuthorId = (int)createBookDto.AuthorId,
                GenreId = (int)createBookDto.GenreId,
                LanguageId = (int)createBookDto.LanguageId,
                CurrencyId = (int)createBookDto.CurrencyId,
                PageNumber = (int)createBookDto.Pages,
                ReleaseDate = (DateTime)createBookDto.ReleaseDate,
                Price = createBookDto.Price,
                AvailabilityId = createBookDto.Available,
            };

            _bookRepository.Add(book);
            _bookRepository.Save();
            return book;
        }

        private bool CheckIfIsbnExists(string isbn)
        {
            return _bookRepository.Find(x => x.Isbn == isbn) != null;
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
            else if (dto.Isbn != book.Isbn && CheckIfIsbnExists(dto.Isbn))
                return null;

            book.Isbn = dto.Isbn;
            book.Title = dto.Title;
            book.AuthorId = (int)dto.AuthorId;
            book.GenreId = (int)dto.GenreId;
            book.LanguageId = (int)dto.LanguageId;
            book.CurrencyId = (int)dto.CurrencyId;
            book.PageNumber = (int)dto.Pages;
            book.ReleaseDate = (DateTime)dto.ReleaseDate;
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
                if (CheckIfIsbnExists(dto.Isbn))
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

        public async Task<PaginatedResult<BookDto>> GetPagedResult(PagedRequest pagedRequest, CancellationToken cancellationToken)
        {
            var bookList = await _bookRepository.GetPagedDataWithInclude(pagedRequest, cancellationToken,
                x => x.Isbn,
                x => x.Title,
                x => x.AuthorId,
                x => x.GenreId,
                x => x.LanguageId,
                x => x.CurrencyId,
                x => x.PageNumber,
                x => x.ReleaseDate,
                x => x.AvailabilityId,
                x => x.Price);
            var list = _mapper.Map<PaginatedResult<BookDto>>(bookList);
            return list;
        }

       
    }
}
