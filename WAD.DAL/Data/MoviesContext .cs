using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using WAD.CW1._00012429.Models;

namespace WAD.CW1._00012429.Data
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<Movie> Movies { get; set; }
		public DbSet<Review> Reviews { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Movie>()
				.HasMany(m => m.Reviews)
				.WithOne(r => r.Movie)
				.HasForeignKey(r => r.MovieId);
		}
	}
}
