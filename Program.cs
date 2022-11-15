using ReadersWritersProblem;

Library _library= new Library();
Random _rnd = new Random();

var thread1 = new Thread(() => { LibraryWork("Ikhmat"); });
thread1.Start();

var thread2 = new Thread(() => { LibraryWork("Karina"); });
thread2.Start();

var thread3 = new Thread(() => { LibraryWork("Janat"); });
thread3.Start();

Console.ReadKey();



void LibraryWork(string threadName)
{
	for (int i = 0; i < 50; i++)
	{
		var bookId = _rnd.Next(1, 10);

		if (_library.IsBookAvailable(bookId))
		{
			var book = _library.GetBookById(bookId);

			if (string.IsNullOrEmpty(book))
			{
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.WriteLine($"{threadName}: book with id {bookId} is not available now");
                Console.ResetColor();
            }
			else
			{
				Console.ForegroundColor = ConsoleColor.DarkGreen;
				Console.WriteLine($"{threadName}: book with id {bookId} is available now");
                Console.ResetColor();
            }
        }
		else
		{
			Console.ForegroundColor = ConsoleColor.DarkMagenta;
			Console.WriteLine($"{threadName}: book with id {bookId} is not found");
            Console.ResetColor();
        }

		Thread.Sleep(2000);
    }
}