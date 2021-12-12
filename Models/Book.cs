using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KibritAPI.Models
{
    public class Book
    {
        [MaxLength(40)]
        public string Id { get; set; }
        
        public string Name { get; set; }

        public ICollection<Author> Authors { get; set; } = new List<Author>();
        public ICollection<Genre> Genres { get; set; } = new List<Genre>();
    }
}