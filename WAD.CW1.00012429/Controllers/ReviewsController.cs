using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WAD.CW1._00012429.Dtos;
using WAD.CW1._00012429.Models;
using WAD.CW1._00012429.Services;

namespace WAD.CW1._00012429.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReviewController : ControllerBase
	{
		private readonly IReviewRepository _reviewRepository;
		private readonly IMapper _mapper;

		public ReviewController(IReviewRepository reviewRepository, IMapper mapper)
		{
			_reviewRepository = reviewRepository;
			_mapper = mapper;
		}

		[HttpGet("{movieId}")]
		public ActionResult<IEnumerable<ReviewDto>> GetByMovieId(int movieId)
		{
			var reviews = _reviewRepository.GetByMovieId(movieId);
			if (reviews == null)
			{
				return NotFound();
			}

			var reviewDtos = _mapper.Map<IEnumerable<ReviewDto>>(reviews);
			return Ok(reviewDtos);
		}

		[HttpGet("{id}")]
		public ActionResult<ReviewDto> Get(int id)
		{
			var review = _reviewRepository.GetById(id);
			if (review == null)
			{
				return NotFound();
			}

			var reviewDto = _mapper.Map<ReviewDto>(review);
			return Ok(reviewDto);
		}

		[HttpPost]
		public ActionResult<ReviewDto> Create([FromBody] ReviewDto reviewDto)
		{
			var review = _mapper.Map<Review>(reviewDto);
			_reviewRepository.Add(review);
			return Ok(reviewDto);
		}

		[HttpPut("{id}")]
		public IActionResult Update(int id, [FromBody] ReviewDto reviewDto)
		{
			var existingReview = _reviewRepository.GetById(id);
			if (existingReview == null)
			{
				return NotFound();
			}

			_mapper.Map(reviewDto, existingReview);
			_reviewRepository.Update(existingReview);
			return Ok("Updated");
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var review = _reviewRepository.GetById(id);
			if (review == null)
			{
				return Ok("Deleted");
			}

			_reviewRepository.Delete(id);
			return NoContent();
		}
	}
}
