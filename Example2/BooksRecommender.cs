using System;
using System.Collections.Generic;

namespace Example2
{
	public class BooksRecommender
	{
		public Library Library { get; set; }

		public List<KeyValuePair<Book, Book>> SimilarBooks { get; set; }

		public BooksRecommender(Library books)
		{
			Library = books;
			SimilarBooks = new KeyValuePair<Book, Book>>();
		}

		public IEnumerable<Book> GetBooksByGenre(string genre)
		{
			return Library.Books.FindAll(x => x.Genre == genre);
		}

		public List<Book> RecommendByBook(Book bookForRecommendation)
		{
			var recommendBooks = new List<Book>();

			foreach (var bookPair in SimilarBooks)
			{
				if (bookForRecommendation == bookPair.Key)
				{
					recommendBooks.Add(bookPair.Value);
				}
				if (bookForRecommendation == bookPair.Value)
				{
					recommendBooks.Add(bookPair.Key);
				}
			}
			return recommendBooks;
		}

		public void CreateBookRecommendations(Book book1, Book book2)
		{
			AddLibraryIfNotPresent(book1);
			AddLibraryIfNotPresent(book2);

			SimilarBooks.Add(new KeyValuePair<Book, Book>(book1, book2));
		}

		private void AddLibraryIfNotPresent(Book book)
		{
			if (!Library.Books.Contains(book))
			{
				Library.AddBook(book);
			}
		}
	}
}
