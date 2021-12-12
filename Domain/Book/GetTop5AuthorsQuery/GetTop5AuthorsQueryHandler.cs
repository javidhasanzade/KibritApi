using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KibritAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KibritAPI.Domain.Book.GetTop5AuthorsQuery
{
    public class GetTop5AuthorsQueryHandler : IRequestHandler<GetTop5AuthorsQuery, List<Author>>
    {
        private readonly MyDbContext _context;

        public GetTop5AuthorsQueryHandler(MyDbContext context)
        {
            _context = context;
        }
        public async Task<List<Author>> Handle(GetTop5AuthorsQuery request, CancellationToken cancellationToken)
        {
            List<Author> authors;
            if (request.Type)
            {
                authors = await _context.Authors
                    .Include(x => x.Books)
                    .OrderByDescending(x => x.Books.Count()).Take(5).ToListAsync(cancellationToken: cancellationToken);
            }
            else
            {
                authors = await _context.Authors
                    .Include(x => x.Books)
                    .OrderBy(x => x.Books.Count()).Take(5).ToListAsync(cancellationToken: cancellationToken);
            }
            

            return await Task.FromResult(authors);
        }
    }
}