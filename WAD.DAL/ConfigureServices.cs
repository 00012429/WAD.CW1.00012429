using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WAD.CW1._00012429.Data;
using WAD.CW1._00012429.Services;

namespace WAD.DAL
{
	public static class ConfigureServices
	{
		public static IServiceCollection ConfigureDAL(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			services.AddScoped<IMovieRepository, MovieRepository>();
			services.AddScoped<IReviewRepository, ReviewRepository>();

			return services;
		}
	}
}
