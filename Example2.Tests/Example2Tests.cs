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

			library.AddBook("1984", "George Orwell", "Fiction");

			Assert.That(library.Books.FirstOrDefault().Title, Is.EqualTo("1984"));
			Assert.That(library.Books.FirstOrDefault().Author, Is.EqualTo("George Orwell"));
			Assert.That(library.Books.FirstOrDefault().Genre, Is.EqualTo("Fiction"));
		}

		[Test]
		public void BookWithNoGenreCanBeAdded()
		{
			var library = new Library();

			library.AddBook("1984", "George Orwell");

			Assert.That(library.Books.FirstOrDefault().Title, Is.EqualTo("1984"));
			Assert.That(library.Books.FirstOrDefault().Author, Is.EqualTo("George Orwell"));
			Assert.That(library.Books.FirstOrDefault().Genre, Is.EqualTo(""));
		}

		[Test]
		public void BooksCanBeRecommendedByGenre()
		{
			var library = new Library();

			library.AddBook("1984", "George Orwell", "Fiction");
			
			var recommender = new BooksRecommender(library);

			Assert.That(recommender.GetBooksByGenre("Fiction").FirstOrDefault().Title, Is.EqualTo("1984"));
			Assert.That(recommender.GetBooksByGenre("Fiction").FirstOrDefault().Author, Is.EqualTo("George Orwell"));
			Assert.That(recommender.GetBooksByGenre("Fiction").FirstOrDefault().Genre, Is.EqualTo("Fiction"));
		}


		[Test]
		public void BooksCanBeRecommendedByTitle()
		{
			var library = new Library();

			var book1 = new Book("1984", "George Orwell", "Fiction");
			var book2 = new Book("Slaughterhouse-Five", "Kurt Vonnegut", "Semi-Autobiographical");
			var book3 = new Book("Fahrenheit 451", "Ray Bradbury", "Dystopian");

			library.AddBook(book1.Title, book1.Author, book1.Genre);
			library.AddBook(book2.Title, book2.Author, book2.Genre);
			library.AddBook(book3.Title, book3.Author, book3.Genre);

			var recomender = new BooksRecommender(library);

			recomender.LinkSimilarBooks(book1,book2);

			var booksIMayLike = recomender.RecommendByBook("1984");

			Assert.That(booksIMayLike.FirstOrDefault().Author, Is.EqualTo("Kurt Vonnegut"));
			Assert.That(booksIMayLike.FirstOrDefault().Title, Is.EqualTo("Slaughterhouse-Five"));
		}
    }
}
