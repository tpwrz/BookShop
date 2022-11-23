using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Services;
using BookShop.Dtos;

namespace BookShop.Controllers
{
    public class BookController
    {
        [Microsoft.AspNetCore.Components.Route("api/[controller]")]
        [ApiController]
        public class BooksController : ControllerBase
        {
            private readonly IMapper _mapper;
            private readonly IBookService _bookService;

            public BooksController(IBookService bookService, IMapper mapper)
            {
                _bookService = bookService;
                _mapper = mapper;
            }

            [HttpGet]
            public IActionResult Get([FromQuery] FilterOptions filterOptions)
            {
                var query = HttpContext.Request.Query;

                var books = _bookService.GetBooks(filterOptions);
                var result = books.Select(e => _mapper.Map<BookDto>(e));

                return Ok(result);
            }

            [HttpGet("{id}")]
            public IActionResult Get(int id)
            {
                var book = _bookService.GetBookById(id);
                if (book == null)
                    return NotFound();

                var result = _mapper.Map<BookDto>(book);
                return Ok(result);
            }

            [HttpPost]
            public IActionResult Post([FromBody] CreateBookDto dto)
            {
                var book = _bookService.AddNewBook(dto);

                if (book == null)
                    return BadRequest("Employee with such IDNP already exists");

                return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
            }

            [HttpPut("{id}")]
            public IActionResult Put(int id, [FromBody] CreateBookDto dto)
            {
                var book = _bookService.UpdateBook(id, dto);

                if (book == null)
                    return BadRequest("Another employee with such idnp already exists");

                return NoContent();
            }

            [HttpPatch("{id}")]
            //[ApiExceptionFilter]
            public IActionResult Patch(int id, [FromBody] UpdateBookDto dto)
            {
                var employee = _bookService.UpdateBookDetails(id, dto);

                if (employee == null)
                    return NotFound();

                var result = _mapper.Map<BookDto>(employee);
                return Ok(result);
            }
        }
    }
}
