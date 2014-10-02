namespace Example2
{
	public class Book
	{
		public string Author { get; set; }
		public string Title { get; set; }
		public string Genre { get; set; }

		public Book(string title, string author, string genre)
		{
			Title = title;
			Author = author;
			Genre = genre;
		}
	}
}
