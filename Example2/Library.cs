using System.Collections.Generic;

namespace Example2
{
    public class Library
    {

		public List<KeyValuePair<string, string>> BooksAndAuthors { get; set; }

		public List<KeyValuePair<string, string>> BooksAndGenres { get; set; }

		public List<KeyValuePair<string, string>> BooksThatCanBeReccomendedBasedOnAnotherBook { get; set; } 


	    public Library()
	    {
		    BooksAndAuthors = new List<KeyValuePair<string, string>>();
			BooksAndGenres = new List<KeyValuePair<string, string>>();
	    }

	    public void AddBook(string bookName, string author, string genre)
		{
			BooksAndAuthors.Add(new KeyValuePair<string, string>(author,bookName));
			BooksAndGenres.Add(new KeyValuePair<string, string>(bookName, genre));
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
