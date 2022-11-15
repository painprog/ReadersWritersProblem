namespace ReadersWritersProblem
{
    public class Library : CustomMonitor
    {
        private readonly List<Book> _books;

        public Library()
        {
            _books = new List<Book>
            {
                new Book
                {
                    Id = 1,
                    Name = "Pride and Prejudice",
                    Author = "Jane Austen",
                    InStockCount = 10
                },
                new Book
                {
                    Id = 2,
                    Name = "To Kill a Mockingbird",
                    Author = "Harper Lee",
                    InStockCount = 10
                },
                new Book
                {
                    Id = 3,
                    Name = "One Hundred Years of Solitude",
                    Author = "Gabriel García",
                    InStockCount = 10
                },
                new Book
                {
                    Id = 4,
                    Name = "Jane Eyre",
                    Author = "Charlotte Bronte",
                    InStockCount = 10
                }
            };
        }

        public bool IsBookAvailable(int id)
        {
            StartRead();

            bool result = _books.Any(x => x.Id == id);

            EndRead();

            return result;
        }

        public string? GetBookById(int id)
        {
            StartWrite();

            var book = _books.FirstOrDefault(x => x.Id == id && x.InStockCount > 0);

            if (book != null)
                book.InStockCount--;

            EndWrite();

            return book?.ToString();
        }
    }
}
