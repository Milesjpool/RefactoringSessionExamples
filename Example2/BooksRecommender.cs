using System;
using System.Collections.Generic;
using System.Linq;

namespace Example2
{
	public class BooksRecommender
	{
		private Library Library { get; set; }
		private List<LinkedBooks> SimilarBooks { get; set; }

		public BooksRecommender(Library library)
		{
			Library = library;
			SimilarBooks = new List<LinkedBooks>();
		}

		public IEnumerable<Book> GetBooksByGenre(string genre)
		{
			return Library.Books.FindAll(x => x.Genre == genre);
		}

		public IEnumerable<Book> RecommendByBook(Book book)
		{
			return (from bookPair in SimilarBooks where bookPair.Contains(book) select bookPair.MatchedBook).ToList();
		}

		public void LinkSimilarBooks(Book book1, Book book2)
		{
			AddBookToLibraryIfNotPresent(book1);
			AddBookToLibraryIfNotPresent(book2);

			SimilarBooks.Add(new LinkedBooks(book1, book2));
		}

		private void AddBookToLibraryIfNotPresent(Book book)
		{
			if (Library.Books.All(x => x.Title != book.Title))
			{
				Library.AddBook(book);
			}
		}

	}
}
