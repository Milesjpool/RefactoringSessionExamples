using System;
using System.Collections.Generic;

namespace Example2
{
	public class BooksRecommender
	{
		public Library Library { get; set; }

		public List<KeyValuePair<string, string>> RecommendedBooks { get; set; }

		public BooksRecommender(Library books)
		{
			Library = books;
			RecommendedBooks = new List<KeyValuePair<string, string>>();

		}

		public List<Book> GetBooksByGenre(string genre)
		{
			return Library.Books.FindAll(x => x.Genre == genre);
		}


		public object RecommendByBook(string title, string author)
		{
			List<KeyValuePair<string, string>> recommendBooks = new List<KeyValuePair<string, string>>();
			String PossibleBook;
			//go through the list of books in the library
			foreach (var book in Library.BooksAndAuthors)
			{
				//if there is a book in the library with the same title as the book asked for a recomendation
				if (title == book.Value)
				{
					//find books with the same title in recomended books
					foreach (var bookForRecomendation in RecommendedBooks)
					{
						foreach (var bookForRecomendationToUser in this.RecommendedBooks)
						{
							if (bookForRecomendationToUser.Key == title)
							{
								PossibleBook = bookForRecomendation.Value;

								foreach (var bookMaybe in Library.BooksAndAuthors)
								{
									if (bookMaybe.Value == PossibleBook)
									{
										recommendBooks.Add(bookMaybe);
									}
								}
							}
						}

					}
				}
			}

			return recommendBooks;
		}

		public void CreateBookRecommendations(string title1, string author1, string genre1, string title2, string author2, string genre2)
		{

			AddLibraryIfNotPresent(title1, author1, genre1);
			AddLibraryIfNotPresent(title2, author2, genre2);

			RecommendedBooks.Add(new KeyValuePair<string, string>(title1,title2));


		}

		private void AddLibraryIfNotPresent(string title1, string author1, string genre1)
		{
			if (Library.BooksAndAuthors.Find(x => x.Value == title1).Value == null)
			{
				Library.AddBook(title1, author1, genre1);
			}
		}
	}
}
