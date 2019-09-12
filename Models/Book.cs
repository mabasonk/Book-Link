using System;
using System.ComponentModel.DataAnnotations;

namespace Book_Link.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Author { get; set; }
        public string Title { get; set; }
        public int YearPublished { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; }
    }
}