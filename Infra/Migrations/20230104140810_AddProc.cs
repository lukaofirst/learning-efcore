using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
	public partial class AddProc : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql(@"CREATE PROCEDURE sp_GetTeamByName
                                @teamName nvarchar(max) 
                           AS 
                           BEGIN 
                                SELECT * FROM Teams WHERE Name = @teamName
                           END");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql(@"DROP PROCEDURE [dbo].[sp_GetTeamByName]");
		}
	}
}
