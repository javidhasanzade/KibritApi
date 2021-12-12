using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using KibritAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KibritAPI.Domain.Book.GetBookQuery
{
    public class GetBookQueryHandler : IRequestHandler<GetBookQuery, Models.Book>
    {
        private readonly MyDbContext _context;

        public GetBookQueryHandler(MyDbContext context)
        {
            _context = context;
        }
        
        public Task<Models.Book> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            //var book = _context.Books.Include(x => x.Authors).Include(x => x.Genres).FirstOrDefault(x => x.Id == request.Id);
            // if (book != null)
            //     return Task.FromResult(book);
            // else
            //     throw new Exception();
            _context.Books.Include(x => x.Authors).Include(x => x.Genres);
            var books = _context.Books.Include(x => x.Authors).Include(x => x.Genres).ToList();

            var book = books.First(x => x.Id == request.Id);
            return Task.FromResult(book);
        }
    }
}