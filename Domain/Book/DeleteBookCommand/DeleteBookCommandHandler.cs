using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KibritAPI.Models;
using MediatR;

namespace KibritAPI.Domain.Book.DeleteBookCommand
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
    {
        private readonly MyDbContext _context;

        public DeleteBookCommandHandler(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == request.Id);
            if (book != null) _context.Books.Remove(book);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}