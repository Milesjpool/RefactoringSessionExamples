using System;
using System.Collections.Generic;
using System.Linq;

namespace Example2
{
	public class BooksRecommender
	{
		public Library Library { get; set; }
		public List<KeyValuePair<Book, Book>> SimilarBooks { get; set; }

		public BooksRecommender(Library library)
		{
			Library = library;
			SimilarBooks = new List<KeyValuePair<Book, Book>>();
		}

		public List<Book> GetBooksByGenre(string genre)
		{
			return Library.Books.FindAll(x => x.Genre == genre);
		}


		public List<Book> RecommendByBook(string title)
		{
			var recommendations = new List<Book>();

			var book = Library.Books.Find(x => x.Title == title);

			foreach (var bookPair in SimilarBooks)
			{
				if (book.Title == bookPair.Key.Title)
				{
					recommendations.Add(bookPair.Value);
				}
				else if (book.Title == bookPair.Value.Title)
				{
					recommendations.Add(bookPair.Key);
				}
			}

			return recommendations;
		}

		public void LinkSimilarBooks(Book book1, Book book2)
		{
			AddBookToLibraryIfNotPresent(book1);
			AddBookToLibraryIfNotPresent(book2);

			SimilarBooks.Add(new KeyValuePair<Book, Book>(book1, book2));
		}

		private void AddBookToLibraryIfNotPresent(Book book)
		{
			if (!Library.Books.Any(x => x.Title == book.Title))
			{
				Library.AddBook(book.Title, book.Author, book.Genre);
			}
		}

	}
}
