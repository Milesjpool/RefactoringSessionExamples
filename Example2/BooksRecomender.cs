﻿using System;
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
			return Books.BooksByGenreFromTitle.FindAll(x => x.Value == typeOfBook);
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

		public void RecommendBook(string title1, string author1, string genreOfBook1, string titleOfBook2, string authorOfBook2, string typeofBook2)
		{

			if (Books.BooksAndAuthors.Find(x => x.Value == title1).Value == null)
			{
				Books.AddBook(title1, author1, genreOfBook1);
			}

			if (Books.BooksAndAuthors.Find(x => x.Value == titleOfBook2).Value == null)
			{
				Books.AddBook(titleOfBook2,authorOfBook2,typeofBook2);
			}

			RecommendedBooks.Add(new KeyValuePair<string, string>(title1,titleOfBook2));


		}
	}
}
