using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
	public partial class CodeUnique : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateIndex(
				name: "IX_DiscountCodes_Code",
				table: "DiscountCodes",
				column: "Code",
				unique: true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropIndex(
				name: "IX_DiscountCodes_Code",
				table: "DiscountCodes");
		}
	}
}