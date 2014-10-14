using System.Collections.Generic;

namespace Example2
{
    public class Library
    {
	    public List<Book> Books { get; private set; }

	    public Library()
	    {
			Books = new List<Book>();
	    }

	    public void AddBook(Book book)
		{
			Books.Add(book);
		}
    }
}
