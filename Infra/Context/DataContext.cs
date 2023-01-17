using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
			// You can let this empty
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Team>()
				.HasOne<League>(t => t.League)
				.WithMany(l => l.Teams)
				.HasForeignKey(t => t.LeagueId);

			modelBuilder.Entity<Team>()
				.HasOne<Coach>(t => t.Coach)
				.WithOne(c => c.Team)
				.HasForeignKey<Coach>(x => x.TeamId);

			modelBuilder.Entity<TeamMatch>().HasKey(tm => new { tm.Id, tm.TeamId, tm.MatchId });

			modelBuilder.Entity<TeamMatch>()
			.Property(f => f.Id)
			.ValueGeneratedOnAdd();

			modelBuilder.Entity<TeamMatch>()
				.HasOne(tm => tm.Team)
				.WithMany(t => t.TeamMatch)
				.HasForeignKey(m => m.TeamId)
				.IsRequired()
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<TeamMatch>()
				.HasOne(tm => tm.Match)
				.WithMany(t => t.TeamMatch)
				.HasForeignKey(m => m.MatchId)
				.IsRequired()
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<TeamsLeaguesView>()
				.HasNoKey()
				.ToView("TeamsLeagues");
		}

		public DbSet<Team>? Teams { get; set; }
		public DbSet<TeamMatch>? TeamMatches { get; set; }
		public DbSet<Match>? Matches { get; set; }
		public DbSet<Coach>? Coaches { get; set; }
		public DbSet<TeamsLeaguesView>? TeamsLeaguesView { get; set; }
	}
}