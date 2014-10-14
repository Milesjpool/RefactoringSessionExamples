using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Example2.Tests
{
	[TestFixture]
    public class Example2Tests
    {
		[Test]
		public void BookCanBeAddedToLibrary()
		{
			var library = new Library();
			var book = new Book("1984", "George Orwell", "Fiction");
			
			library.AddBook(book);

			Assert.That(library.Books.FirstOrDefault(), Is.EqualTo(book));
		}

		[Test]
		public void BookWithNoGenreCanBeAdded()
		{
			var library = new Library();
			var book = new Book("1984", "George Orwell");

			library.AddBook(book);

			Assert.That(library.Books.FirstOrDefault(), Is.EqualTo(book));

		}

		[Test]
		public void BooksCanBeRecommendedByGenre()
		{
			var library = new Library();
			var book = new Book("1984", "George Orwell", "Fiction");

			library.AddBook(book);

			var recommender = new BooksRecommender(library);

			Assert.That(recommender.GetBooksByGenre("Fiction").FirstOrDefault(), Is.EqualTo(book));
		}

		[Test]
		public void BooksCanBeRecommendedByTitle()
		{
			var library = new Library();

			var book1 = new Book("1984", "George Orwell", "Fiction");
			var book2 = new Book("Slaughterhouse-Five", "Kurt Vonnegut", "Semi-Autobiographical");
			var book3 = new Book("Fahrenheit 451", "Ray Bradbury", "Dystopian");

			library.AddBook(book1);
			library.AddBook(book2);
			library.AddBook(book3);

			var recomender = new BooksRecommender(library);

			recomender.LinkSimilarBooks(book1,book2);

			var booksIMayLike = recomender.RecommendByBook(book1);

			Assert.That(booksIMayLike.FirstOrDefault(), Is.EqualTo(book2));
		}
    }
}
