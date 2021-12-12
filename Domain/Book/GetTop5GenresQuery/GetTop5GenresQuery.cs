using System.Collections.Generic;
using KibritAPI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KibritAPI.Domain.Book.GetTop5GenresQuery
{
    public class GetTop5GenresQuery : IRequest<List<Genre>>
    {
        [FromRoute] public bool Type { get; set; } = true;
    }
}