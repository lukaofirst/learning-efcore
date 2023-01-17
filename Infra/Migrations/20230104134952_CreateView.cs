using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
	public partial class CreateView : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql(@"CREATE VIEW [dbo].[TeamsLeagues]
									AS
									SELECT t.Name AS TeamName, l.Name AS LeagueName
										FROM dbo.Teams AS t 
										INNER JOIN 
										dbo.League AS l ON t.leagueId = l.Id;");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql(@"DROP VIEW [dbo].[TeamsLeagues]");
		}
	}
}
