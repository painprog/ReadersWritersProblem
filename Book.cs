using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadersWritersProblem
{
    public class Book
    {
        public int Id { get; set; } 
        public string? Name { get; set; }
        public string? Author { get; set; }
        public int InStockCount { get; set; }

        public override string? ToString()
            => $"Id: {Id}, Book: {Name}, Author: {Author}";
    }
}
