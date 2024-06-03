using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SubjectAPISnackis.Migrations
{
	/// <inheritdoc />
	public partial class snackisramin : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			// Kontrollera om tabellen redan existerar
			migrationBuilder.Sql(@"
                IF OBJECT_ID(N'[dbo].[Subjects]', N'U') IS NULL
                BEGIN
                    CREATE TABLE [Subjects] (
                        [Id] int NOT NULL IDENTITY,
                        [Category] nvarchar(max) NOT NULL,
                        CONSTRAINT [PK_Subjects] PRIMARY KEY ([Id])
                    );
                END
            ");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Subjects");
		}
	}
}
