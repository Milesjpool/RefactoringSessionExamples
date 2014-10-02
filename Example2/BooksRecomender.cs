using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example2
{
	public class BooksRecomender
	{
		public Library Books { get; set; }

		public List<KeyValuePair<string, string>> RecommendedBooks { get; set; } 

		public BooksRecomender(Library books)
		{
			Books = books;
			RecommendedBooks = new List<KeyValuePair<string, string>>();

		}

		public List<KeyValuePair<string, string>> GetBooksByGenre(string typeOfBook)
		{
			return Books.BooksAndGenres.FindAll(x => x.Value == typeOfBook);
		}


		public object FindMeBooksIMayLikeBasedOnThisBook(string title, string writer, string shelfItBelongsOn)
		{
			//list to return
			List<KeyValuePair<string, string>> returnableRecommendBooks = new List<KeyValuePair<string, string>>();
			String PossibleBook;
			//go through the list of books in the library
			foreach (var book in Books.BooksAndAuthors)
			{
				//if there is a book in the library with the same title as the book asked for a recomendation
				if (title == book.Value)
				{
					var bookPossibleToRecomend = book.Value;

					//find books with the same title in recomended books
					foreach (var bookForRecomendation in RecommendedBooks)
					{
						//if you find one with the same title in the list of recomnded books
						if (bookForRecomendation.Value == bookPossibleToRecomend)
						{
							var AnewBook = Books.BooksAndAuthors.FirstOrDefault(x => x.Value == bookForRecomendation.Value);
						}

						foreach (var bookForRecomendationToUser in this.RecommendedBooks)
						{
							if (bookForRecomendationToUser.Key == title)
							{
								PossibleBook = bookForRecomendation.Value;

								foreach (var bookMaybe in Books.BooksAndAuthors)
								{
									if (bookMaybe.Value == PossibleBook)
									{
										returnableRecommendBooks.Add(bookMaybe);
									}
								}
							}
						}

					}
				}
			}

			return returnableRecommendBooks;
		}

		public void CreateBookRecommendations(string title1, string author1, string genre1, string title2, string author2, string genre2)
		{

			AddLibraryIfNotPresent(title1, author1, genre1);
			AddLibraryIfNotPresent(title2, author2, genre2);

			RecommendedBooks.Add(new KeyValuePair<string, string>(title1,title2));


		}

		private void AddLibraryIfNotPresent(string title1, string author1, string genre1)
		{
			if (Books.BooksAndAuthors.Find(x => x.Value == title1).Value == null)
			{
				Books.AddBook(title1, author1, genre1);
			}
		}
	}
}
