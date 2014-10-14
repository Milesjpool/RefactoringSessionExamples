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

			library.AddBook(new Book("1984", "George Orwell", "Fiction"));

			Assert.That(library.Books.FirstOrDefault().Title, Is.EqualTo("1984"));
			Assert.That(library.Books.FirstOrDefault().Author, Is.EqualTo("George Orwell"));
			Assert.That(library.Books.FirstOrDefault().Genre, Is.EqualTo("Fiction"));
		}

		[Test]
		public void BookWithNoGenreCanBeAdded()
		{
			var library = new Library();

			library.AddBook( new Book("1984", "George Orwell"));

			Assert.That(library.Books.FirstOrDefault().Title, Is.EqualTo("1984"));
			Assert.That(library.Books.FirstOrDefault().Author, Is.EqualTo("George Orwell"));
			Assert.That(library.Books.FirstOrDefault().Genre, Is.EqualTo(""));
		}

		[Test]
		public void BooksCanBeRecommendedByGenre()
		{
			var library = new Library();

			library.AddBook(new Book("1984", "George Orwell", "Fiction"));
			
			var recommender = new BooksRecommender(library);

			Assert.That(recommender.GetBooksByGenre("Fiction").FirstOrDefault().Title, Is.EqualTo("1984"));
			Assert.That(recommender.GetBooksByGenre("Fiction").FirstOrDefault().Author, Is.EqualTo("George Orwell"));
			Assert.That(recommender.GetBooksByGenre("Fiction").FirstOrDefault().Genre, Is.EqualTo("Fiction"));
		}


		[Test]
		public void BooksCanBeRecommendedByAuthor()
		{
			var library = new Library();

			library.AddBook(new Book("1984", "George Orwell", "Fiction"));
			library.AddBook(new Book("Slaughterhouse-Five", "Kurt Vonnegut", "Semi-Autobiographical"));
			library.AddBook(new Book("Fahrenheit 451", "Ray Bradbury", "Dystopian"));

			var recomender = new BooksRecommender(library);

			var book1 = new Book("1984", "George Orwell", "Fiction");
			var book2 = new Book("Slaughterhouse-Five", "Kurt Vonnegut", "Semi-Autobiographical");
			recomender.CreateBookRecommendations(book1, book2);

			Assert.That(recomender.RecommendByBook(book1).FirstOrDefault(), Is.EqualTo(book2));
		}
    }
}
