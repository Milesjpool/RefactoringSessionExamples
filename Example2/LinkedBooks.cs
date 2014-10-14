namespace Example2
{
	public class LinkedBooks
	{
		protected Book Book1 { get; set; }
		protected Book Book2 { get; set; }
		public Book MatchedBook { get; private set; }

		public LinkedBooks(Book book1, Book book2)
		{
			Book1 = book1;
			Book2 = book2;
		}

		public bool Contains(Book book)
		{
			if (Book1 == book)
			{
				MatchedBook = Book2;
				return true;
			}
			if (Book2 == book)
			{
				MatchedBook = Book1;
				return true;
			}
			return false;
		}
	}
}