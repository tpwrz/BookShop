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
    internal class BookService : IBookService
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
                Author = createBookDto.Author,
                Genre = createBookDto.Genre,
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

                // We can also use PUT to create a new resource, but it also will require explicit identity insert in our case
                /* employee = new Employee();
                employee.Id = id;
                _employeeRepository.Add(employee);*/
            }
            else if (dto.Isbn != book.Isbn && CheckIfIdnpExists(dto.Isbn))
                return null;

            book.Isbn = dto.Isbn;
            book.Title = dto.Title;
            book.Author = dto.Author;
            book.Price = dto.Price;

            _bookRepository.Save();
            return book;
        }

        public Book UpdateEmployeeDetails(int id, UpdateBookDto dto)
        {
            var book = _bookRepository.Find(id);
            if (book == null)
                return null;

            if (!string.IsNullOrWhiteSpace(dto.Title))
                book.Title = dto.Title;

            if (!string.IsNullOrWhiteSpace(dto.Author))
                book.Author = dto.Author;

            if (dto.Isbn.HasValue && book.Isbn != dto.Isbn.Value)
            {
                if (CheckIfIdnpExists(dto.Isbn.Value))
                {
                    throw new Exception("Another user with such IDNP already exists in the system!");
                }
                book.Isbn = dto.Isbn.Value;
            }

            if (dto.Price.HasValue)
            {
                book.Price = dto.Price.Value;
            }

            _bookRepository.Save();
            return book;
        }

        private bool CheckIfIdnpExists(long isbn)
        {
            return _bookRepository.Find(x => x.Isbn == isbn) != null;
        }
    }
}
