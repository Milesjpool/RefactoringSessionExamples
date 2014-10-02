using System.Collections.Generic;

namespace Example2
{
    public class Library
    {

		public List<KeyValuePair<string, string>> BooksAndAuthors { get; set; }

		public List<KeyValuePair<string, string>> BooksAndGenres { get; set; }

	    public List<Book> Books { get; set; }

		public List<KeyValuePair<string, string>> BooksThatCanBeReccomendedBasedOnAnotherBook { get; set; } 


	    public Library()
	    {
		    BooksAndAuthors = new List<KeyValuePair<string, string>>();
			BooksAndGenres = new List<KeyValuePair<string, string>>();
			Books = new List<Book>();
	    }

	    public void AddBook(string title, string author, string genre)
		{
			BooksAndAuthors.Add(new KeyValuePair<string, string>(author,title));
			BooksAndGenres.Add(new KeyValuePair<string, string>(title, genre));

			Books.Add(new Book(title,author,genre));
		}

	    public List<KeyValuePair<string,string>> GetBooksByGenre(string typeOfBook)
	    {
		    return BooksAndGenres.FindAll(x => x.Value == typeOfBook);
	    }

		public void AddBookWithNoGenre(string bookName, string author)
		{
			BooksAndAuthors.Add(new KeyValuePair<string, string>(author, bookName));
		}
    }
}
