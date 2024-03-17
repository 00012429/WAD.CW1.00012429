using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WAD.CW1._00012429.Dtos;
using WAD.CW1._00012429.Models;
using WAD.CW1._00012429.Services;

namespace WAD.CW1._00012429.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MovieController : ControllerBase
	{
		private readonly IMovieRepository _movieRepository;
		private readonly IMapper _mapper;

		public MovieController(IMovieRepository movieRepository, IMapper mapper)
		{
			_movieRepository = movieRepository;
			_mapper = mapper;
		}

		[HttpGet]
		public ActionResult<IEnumerable<MovieDto>> GetAll()
		{
			var movies = _movieRepository.GetAll();
			var movieDtos = _mapper.Map<IEnumerable<MovieDto>>(movies);
			return Ok(movieDtos);
		}

		[HttpGet("{id}")]
		public ActionResult<MovieDto> Get(int id)
		{
			var movie = _movieRepository.GetById(id);
			if (movie == null)
			{
				return NotFound();
			}

			var movieDto = _mapper.Map<MovieDto>(movie);
			return Ok(movieDto);
		}

		[HttpPost]
		public ActionResult<MovieDto> Create([FromBody] MovieDto movieDto)
		{
			var movie = _mapper.Map<Movie>(movieDto);
			_movieRepository.Add(movie);
			return Ok(movieDto);
		}

		[HttpPut("{id}")]
		public IActionResult Update(int id, [FromBody] MovieDto movieDto)
		{
			var existingMovie = _movieRepository.GetById(id);
			if (existingMovie == null)
			{
				return NotFound();
			}

			_mapper.Map(movieDto, existingMovie);
			_movieRepository.Update(existingMovie);
			return Ok("Updated");
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var movie = _movieRepository.GetById(id);
			if (movie == null)
			{
				return NotFound();
			}

			_movieRepository.Delete(id);
			return Ok("Deleted");
		}
	}
}
