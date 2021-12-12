using System.Collections.Generic;
using KibritAPI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KibritAPI.Domain.Book.GetTop5AuthorsQuery
{
    public class GetTop5AuthorsQuery : IRequest<List<Author>>
    {
        [FromRoute] public bool Type { get; set; } = true;
    }
}