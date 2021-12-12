using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KibritAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KibritAPI.Domain.Book.GetTop5GenresQuery
{
    public class GetTop5GenresQueryHandler : IRequestHandler<GetTop5GenresQuery, List<Genre>>
    {
        private readonly MyDbContext _context;

        public GetTop5GenresQueryHandler(MyDbContext context)
        {
            _context = context;
        }
        
        public async Task<List<Genre>> Handle(GetTop5GenresQuery request, CancellationToken cancellationToken)
        {
            List<Genre> genres;
            if (request.Type)
            {
                genres = await _context.Genres
                    .Include(x => x.Books)
                    .OrderByDescending(x => x.Books.Count()).Take(5).ToListAsync(cancellationToken: cancellationToken);
            }
            else
            {
                genres = await _context.Genres
                    .Include(x => x.Books)
                    .OrderBy(x => x.Books.Count()).Take(5).ToListAsync(cancellationToken: cancellationToken);
            }
            

            return await Task.FromResult(genres);
        }
    }
}