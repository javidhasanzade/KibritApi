using System.Threading.Tasks;
using KibritAPI.Domain.Book.CreateBookCommand;
using KibritAPI.Domain.Book.DeleteBookCommand;
using KibritAPI.Domain.Book.GetBookQuery;
using KibritAPI.Domain.Book.GetBooksByGenreQuery;
using KibritAPI.Domain.Book.GetTop5AuthorsQuery;
using KibritAPI.Domain.Book.GetTop5GenresQuery;
using KibritAPI.Domain.Book.UpdateBookCommand;
using KibritAPI.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KibritAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Insert(CreateBookCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        
        [HttpGet("{Id}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] GetBookQuery query)
        {
            
            return Ok(await _mediator.Send(query));
        }
        
        [HttpGet("Genre/{Id}")]
        [Authorize]
        public async Task<IActionResult> GetByGenre([FromRoute] GetBooksByGenreQuery query)
        {
            
            return Ok(await _mediator.Send(query));
        }
        
        [HttpGet("Top5Genres/{Type?}")]
        [Authorize]
        public async Task<IActionResult> GetTop5Genres([FromRoute] GetTop5GenresQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        
        [HttpGet("Top5Authors/{Type?}")]
        [Authorize]
        public async Task<IActionResult> GetTop5Authors([FromRoute] GetTop5AuthorsQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        
        [HttpDelete("{Id}")]
        [Authorize]
        public async Task<IActionResult> DeleteById([FromRoute] DeleteBookCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update(UpdateBookCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
