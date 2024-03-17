using static System.Runtime.InteropServices.JavaScript.JSType;
using WAD.CW1._00012429.Dtos;
using WAD.CW1._00012429.Models;
using AutoMapper;

namespace WAD.CW1._00012429.Profiles
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Movie, MovieDto>().ReverseMap();
			CreateMap<Review, ReviewDto>().ReverseMap();
		}
	}
}
