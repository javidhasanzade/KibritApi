using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KibritAPI.Domain.Book.GetBookQuery
{
    public class GetBookQuery : IRequest<Models.Book>, IRequest<Unit>
    {
        [FromRoute]
        public string Id { get; set; }
    }
}