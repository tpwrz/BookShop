using AutoMapper;
using BookShop;
using BookShop.Dtos;
using BookShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] FilterOptions filterOptions)
        {
            var query = HttpContext.Request.Query;

            var books = _orderService.GetOrders(filterOptions);
            var result = books.Select(e => _mapper.Map<OrderDto>(e));

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var book = _orderService.GetOrderById(id);
            if (book == null)
                return NotFound();

            var result = _mapper.Map<OrderDto>(book);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateOrderDto dto)
        {
            var book = _orderService.AddNewOrder(dto);

            if (book == null)
                return BadRequest("Employee with such IDNP already exists");

            return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
        }
        /*
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CreateOrderDto dto)
        {
            var book = _orderService.UpdateOrder(id, dto);

            if (book == null)
                return BadRequest("Another employee with such idnp already exists");

            return NoContent();
        }
        */
       // [HttpPatch("{id}")]
        //[ApiExceptionFilter]
        /*
        public IActionResult Patch(int id, [FromBody] CreateOrderDto dto)
        {
            var employee = _orderService.UpdateOrderDetails(id, dto);

            if (employee == null)
                return NotFound();

            var result = _mapper.Map<BookDto>(employee);
            return Ok(result);
        }*/
    }
}
