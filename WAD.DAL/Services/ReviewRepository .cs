using WAD.CW1._00012429.Data;
using WAD.CW1._00012429.Models;

namespace WAD.CW1._00012429.Services
{
	public class ReviewRepository : IReviewRepository
	{
		private readonly ApplicationDbContext _context;

		public ReviewRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public IEnumerable<Review> GetByMovieId(int movieId)
		{
			return _context.Reviews.Where(r => r.MovieId == movieId).ToList();
		}

		public Review GetById(int id)
		{
			return _context.Reviews.FirstOrDefault(r => r.ReviewId == id);
		}

		public void Add(Review review)
		{
			_context.Reviews.Add(review);
			_context.SaveChanges();
		}

		public void Update(Review review)
		{
			_context.Reviews.Update(review);
			_context.SaveChanges();
		}

		public void Delete(int id)
		{
			var review = _context.Reviews.Find(id);
			if (review != null)
			{
				_context.Reviews.Remove(review);
				_context.SaveChanges();
			}
		}
	}

}
