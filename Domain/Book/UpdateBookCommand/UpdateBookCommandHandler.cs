using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KibritAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KibritAPI.Domain.Book.UpdateBookCommand
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
    {
        private readonly MyDbContext _context;

        public UpdateBookCommandHandler(MyDbContext context)
        {
            _context = context;
        }
        
        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = _context.Books.AsNoTracking().FirstOrDefault(x => x.Id == request.Id);
            book = request;
            _context.Books.Update(book);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;;
        }
    }
}