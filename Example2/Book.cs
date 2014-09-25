namespace Example2
{
	public class Book
	{
		public string Author { get; set; }
		public string Title { get; set; }
		public string Genre { get; set; }

		public Book(string author, string title, string genre)
		{
			Author = author;
			Title = title;
			Genre = genre;
		}
	}
}
