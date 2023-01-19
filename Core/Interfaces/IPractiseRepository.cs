using Core.Entities;

namespace Core.Interfaces
{
	public interface IPractiseRepository
	{
		Task<List<Team>> GetAll();
		Task<Team>? GetById(int id);
		Task<List<TeamsLeaguesView>> GetSQLView();
		Task<Team> GetTeamByName(string teamName);
		Task<Team> Create(Team team);
		Task<Team> Update(Team team);
		Task<bool> Remove(int id);
	}
}