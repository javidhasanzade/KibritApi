using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KibritAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KibritAPI.Domain.Book.GetBooksByGenreQuery
{
    public class GetBooksByGenreQueryHandler : IRequestHandler<GetBooksByGenreQuery, Genre>
    {
        private readonly MyDbContext _context;

        public GetBooksByGenreQueryHandler(MyDbContext context)
        {
            _context = context;
        }
        
        public Task<Genre> Handle(GetBooksByGenreQuery request, CancellationToken cancellationToken)
        {
            var genre = _context.Genres.Include(x => x.Books).FirstOrDefault(x => x.Id == request.Id);
            
            return Task.FromResult(genre);
        }
    }
}