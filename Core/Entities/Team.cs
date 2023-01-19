namespace Core.Entities
{
	public class Team
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public Coach? Coach { get; set; }
		public int LeagueId { get; set; }
		public League? League { get; set; }
		public List<Match> Matches { get; set; } = new();
		public List<TeamMatch> TeamMatch { get; set; } = new();
	}
}