using WAD.CW1._00012429.Models;

namespace WAD.CW1._00012429.Services
{
	public interface IMovieRepository
	{
		IEnumerable<Movie> GetAll();
		Movie GetById(int id);
		void Add(Movie movie);
		void Update(Movie movie);
		void Delete(int id);
	}
}
