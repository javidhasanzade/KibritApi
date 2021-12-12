using System.Collections.Generic;
using KibritAPI.Models;
using MediatR;

namespace KibritAPI.Domain.Book.CreateBookCommand
{
    public class CreateBookCommand : IRequest
    {
        public string BookName { get; set; }
        public List<string> AuthorId { get; set; }
        public List<string> GenreId { get; set; }
    }
}