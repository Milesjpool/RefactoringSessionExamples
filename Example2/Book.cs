using System.Collections.Generic;

namespace Example2
{
	public class Book
	{
		public string Author { get; private set; }
		public string Title { get; private set; }
		public string Genre { get; private set; }

		public Book(string title, string author, string genre = "")
		{
			Title = title;
			Author = author;
			Genre = genre;
		}
	}
}
