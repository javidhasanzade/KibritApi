using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KibritAPI.Domain.Book.DeleteBookCommand
{
    public class DeleteBookCommand : IRequest
    {
        [FromRoute]
        public string Id { get; set; }
    }
}