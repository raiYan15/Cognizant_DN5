using CrudRestApi.Models;
using CrudRestApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CrudRestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _repository;

        public BooksController(IBookRepository repository)
        {
            _repository = repository;
        }

        // GET: api/books
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAll()
        {
            return Ok(_repository.GetAll());
        }

        // GET: api/books/1
        [HttpGet("{id}")]
        public ActionResult<Book> GetById(int id)
        {
            var book = _repository.GetById(id);
            if (book is null) return NotFound($"Book with id {id} not found.");
            return Ok(book);
        }

        // POST: api/books
        [HttpPost]
        public ActionResult<Book> Create([FromBody] Book book)
        {
            var created = _repository.Add(book);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/books/1
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Book book)
        {
            var updated = _repository.Update(id, book);
            if (!updated) return NotFound($"Book with id {id} not found.");
            return NoContent();
        }

        // DELETE: api/books/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _repository.Delete(id);
            if (!deleted) return NotFound($"Book with id {id} not found.");
            return NoContent();
        }
    }
}
