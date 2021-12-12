using System.Collections.Generic;
using KibritAPI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KibritAPI.Domain.Book.GetBooksByGenreQuery
{
    public class GetBooksByGenreQuery : IRequest<Genre>
    {
        [FromRoute] 
        public string Id { get; set; }
    }
}