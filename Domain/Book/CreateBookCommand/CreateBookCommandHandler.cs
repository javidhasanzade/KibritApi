using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KibritAPI.Models;
using MediatR;

namespace KibritAPI.Domain.Book.CreateBookCommand
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand>
    {
        private readonly MyDbContext _context;

        public CreateBookCommandHandler(MyDbContext _context)
        {
            this._context = _context;
        }
        
        public async Task<Unit> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var b1 = new Models.Book
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.BookName
            };
            
            var authors = request.AuthorId.Select(item => _context.Authors.FirstOrDefault(x => x.Id == item)).ToList();
            var genres = request.GenreId.Select(item => _context.Genres.FirstOrDefault(x => x.Id == item)).ToList();

            b1.Authors = authors;
            b1.Genres = genres;
            _context.Books.Add(b1);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}