using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Contexts
{
	public class DiscountCodeContext : DbContext
	{
		public DiscountCodeContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<DiscountCode>()
				.HasIndex(p => new { p.Code })
				.IsUnique(true);
		}

		public DbSet<DiscountCode> DiscountCodes { get; set; }
	}
}