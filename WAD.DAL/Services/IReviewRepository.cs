using WAD.CW1._00012429.Models;

namespace WAD.CW1._00012429.Services
{
	public interface IReviewRepository
	{
		IEnumerable<Review> GetByMovieId(int movieId);
		Review GetById(int id);
		void Add(Review review);
		void Update(Review review);
		void Delete(int id);
	}
}
