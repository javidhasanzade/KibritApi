using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KibritAPI.Models
{
    public class Genre
    {
        [MaxLength(40)]
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Book> Books { get; set; } 
    }
}