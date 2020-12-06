using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETD_Lab5.Models
{
    public class BookAuthor
    {
        public int bookID { get; set; }
        public int authorID { get; set; }

        //Relationships

        public Book Book { get; set; }
        public Author Author { get; set; }
    }
}
