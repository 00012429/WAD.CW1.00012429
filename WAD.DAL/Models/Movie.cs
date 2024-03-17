namespace WAD.CW1._00012429.Models
{
	public class Movie
	{
		public int MovieId { get; set; }
		public string Title { get; set; }
		public string Director { get; set; }
		public DateTime ReleaseDate { get; set; }
		public string Genre { get; set; }
		public ICollection<Review> Reviews { get; set; }
	}
}
