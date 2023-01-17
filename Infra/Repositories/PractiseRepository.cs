using Core.Entities;
using Core.Interfaces;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
	public class PractiseRepository : IPractiseRepository
	{
		private readonly DataContext _context;

		public PractiseRepository(DataContext context)
		{
			_context = context;

		}

		public async Task<Team> Create(Team team)
		{
			using (var transaction = await _context.Database.BeginTransactionAsync())
			{
				try
				{
					await _context.AddAsync(team);
					await _context.SaveChangesAsync();

					await transaction.CommitAsync();

					return team;
				}
				catch (System.Exception)
				{
					throw;
				}
			}
		}

		public async Task<List<Team>> GetAll()
		{
			var arr = new int[] { 1, 2 };

			// LINQ Method
			var entitiesLinqMethod = await _context.Teams!
				.Where(x => arr.Contains(x.Id))
				.AsNoTracking()
				.ToListAsync();

			// LINQ Query
			var entitiesLinqQuery = await (
				from teams in _context.Teams
				where arr.Contains(teams.Id)
				select teams
			).AsNoTracking().ToListAsync();


			return entitiesLinqMethod;
		}

		public async Task<List<TeamsLeaguesView>> GetSQLView()
		{
			var sqlViewResult = await _context.TeamsLeaguesView!.ToListAsync();

			return sqlViewResult;
		}

		public async Task<Team> GetById(int id)
		{
			// LINQ Method
			var entitiesLinqMethod = await _context.Teams!
				.Include(x => x.TeamMatch)
				.AsNoTracking()
				.Where(x => x.Id == id)
				.SingleOrDefaultAsync();

			// LINQ Query
			var entitiesLinqQuery = await (
				from teams in _context.Teams
				join teamMatch in _context.TeamMatches!
				on teams.Id equals teamMatch.TeamId
				join match in _context.Matches!
				on teamMatch.MatchId equals match.Id
				where teams.Id == id
				select new { teams, match }
			).AsNoTracking().Where(x => x.teams.Id == id).ToListAsync();

			return entitiesLinqMethod!;
		}

		public async Task<Team> GetTeamByName(string teamName)
		{
			var storedProcedureResult = await _context.Teams!
				.FromSqlInterpolated($"EXEC sp_GetTeamByName {teamName}")
				.ToListAsync();

			return storedProcedureResult.FirstOrDefault()!;
		}

		public Task<bool> Remove(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<Team> Update(Team team)
		{
			_context.Update(team);
			await _context.SaveChangesAsync();

			return team;
		}
	}
}