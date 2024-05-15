using System.Globalization;
using System.Numerics;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexForCandidates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<BigInteger>(
                name: "Index",
                table: "Candidates",
                type: "numeric",
                nullable: false,
                defaultValue: BigInteger.Parse("0", NumberFormatInfo.InvariantInfo));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Index",
                table: "Candidates");
        }
    }
}
