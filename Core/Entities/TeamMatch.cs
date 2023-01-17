namespace Core.Entities
{
	public class TeamMatch
	{
		public int Id { get; set; }
		public int TeamId { get; set; }
		public Team? Team { get; set; }
		public int MatchId { get; set; }
		public Match? Match { get; set; }
	}
}