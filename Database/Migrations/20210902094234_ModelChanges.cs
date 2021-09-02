using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Database.Migrations
{
	public partial class ModelChanges : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<DateTime>(
				name: "UsedAt",
				table: "DiscountCodes",
				type: "datetime2",
				nullable: true,
				oldClrType: typeof(DateTime),
				oldType: "datetime2");

			migrationBuilder.AlterColumn<string>(
				name: "Code",
				table: "DiscountCodes",
				type: "nvarchar(8)",
				maxLength: 8,
				nullable: false,
				defaultValue: "",
				oldClrType: typeof(string),
				oldType: "nvarchar(max)",
				oldNullable: true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<DateTime>(
				name: "UsedAt",
				table: "DiscountCodes",
				type: "datetime2",
				nullable: false,
				defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
				oldClrType: typeof(DateTime),
				oldType: "datetime2",
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Code",
				table: "DiscountCodes",
				type: "nvarchar(max)",
				nullable: true,
				oldClrType: typeof(string),
				oldType: "nvarchar(8)",
				oldMaxLength: 8);
		}
	}
}