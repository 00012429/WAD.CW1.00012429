namespace WAD.CW1._00012429.Models
{
	public class Review
	{
		public int ReviewId { get; set; }
		public string Content { get; set; }
		public int Rating { get; set; }
		public int MovieId { get; set; }
		public Movie Movie { get; set; }
	}
}
