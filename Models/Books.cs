using System;
using System.Collections.Generic;

namespace NETD_Lab5.Models
{
    public partial class Books
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Version { get; set; }
        public int Copies { get; set; }
        public int Isbn { get; set; }
    }
}
