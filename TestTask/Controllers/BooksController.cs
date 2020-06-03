using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestTask.BLL.DTO;
using TestTask.BLL.Filters;
using TestTask.BLL.Services.Interfaces;

namespace TestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IEntityService<BookDTO> _bookService;

        public BooksController(IEntityService<BookDTO> bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery]AuthorNameFilter filter)
        {
            var response = _bookService.GetAll(filter);

            if (response.Count() != 0)
            {
                return Ok(response);
            }

            return NotFound();
        }

        [HttpGet, Route("{id}")]
        public IActionResult Get(int id)
        {
            var response = _bookService.Get(id);

            if (response != null)
            {
                return Ok(response);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody]BookDTO book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }

            _bookService.Create(book);

            return Ok();
        }

        [HttpPut, Route("{id}")]
        public IActionResult Put(int id, [FromBody]BookDTO book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }

            _bookService.Update(id, book);

            return Ok();
        }

        [HttpDelete, Route("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0)
            {
                return BadRequest("Invalid value of id");
            }

            _bookService.Delete(id);

            return Ok();
        }
    }
}