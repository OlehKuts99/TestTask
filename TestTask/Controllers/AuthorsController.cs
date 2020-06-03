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
    public class AuthorsController : ControllerBase
    {
        private readonly IEntityService<AuthorDTO> _authorService;

        public AuthorsController(IEntityService<AuthorDTO> authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery]AuthorNameFilter filter)
        {
            var response = _authorService.GetAll(filter);

            if (response.Count() != 0)
            {
                return Ok(response);
            }

            return NotFound();
        }

        [HttpGet, Route("{id}")]
        public IActionResult Get(int id)
        {
            var response = _authorService.Get(id);

            if (response != null)
            {
                return Ok(response);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody]AuthorDTO author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }

            _authorService.Create(author);

            return Ok();
        }

        [HttpPut, Route("{id}")]
        public IActionResult Put(int id, [FromBody]AuthorDTO author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }

            _authorService.Update(id, author);

            return Ok();
        }

        [HttpDelete, Route("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0)
            {
                return BadRequest("Invalid value of id");
            }

            _authorService.Delete(id);

            return Ok();
        }
    }
}