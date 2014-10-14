namespace Example2
{
	public class LinkedBooks
	{
		private Book Book1 { get; set; }
		private Book Book2 { get; set; }
		private Book MatchedBook { get; set; }

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