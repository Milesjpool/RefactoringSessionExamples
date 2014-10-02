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
		public void BooksCanBeRetrivedBygenre()
		{
			var library = new Library();

			library.AddBook("1984", "George Orwell", "Fiction");

			Assert.That(library.GetBooksByGenre("Fiction").FirstOrDefault().Title, Is.EqualTo("1984"));
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
		public void BooksCanBeRecomendedByGenre()
		{
			var library = new Library();

			library.AddBook("1984", "George Orwell", "Fiction");

			var recomender= new BooksRecomender(library);

			Assert.That(recomender.GetBooksByGenre("Fiction").FirstOrDefault().Key, Is.EqualTo("1984"));
		}

		[Test]
		public void BooksCanBeRecommendedByAuthor()
		{
			var library = new Library();

			library.AddBook("1984", "George Orwell", "Fiction");
			library.AddBook("Slaughterhouse-Five", "Kurt Vonnegut", "Semi-Autobiographical");
			library.AddBook("Fahrenheit 451", "Ray Bradbury", "Dystopian");

			var recomender = new BooksRecomender(library);

			recomender.CreateBookRecommendations("1984", "George Orwell", "Fiction", "Slaughterhouse-Five", "Kurt Vonnegut", "Semi-Autobiographical");


			var booksIMayLike = recomender.FindMeBooksIMayLikeBasedOnThisBook("1984", "George Orwell", "Fiction");
		}






    }
}
