using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_Model.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public double Price { get; set; }
        [NotMapped]
        public string PriceRange { get; set; }
        public BookDetail BookDetailRef { get; set; }

        [ForeignKey("PublisherRef")]
        public int Publisher_Id { get; set; }
        public Publisher PublisherRef { get; set; }

        public List<Author> Authors { get; set; }
    }
}
