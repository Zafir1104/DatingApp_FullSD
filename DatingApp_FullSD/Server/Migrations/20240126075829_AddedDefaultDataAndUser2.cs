using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DatingApp_FullSD.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultDataAndUser2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Users_UserID1Id",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Users_UserID2Id",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_PUserNameId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Interest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthdate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6b2a4f84-17b4-4714-a0ab-e9e8316b4791", "AQAAAAIAAYagAAAAEJmDeECER0kdAr9LPdcpE5L/XFAP0xa8+mA9zMmrVTCzE8ZJHuXz7ouUdifRzNdi0A==", "67b91441-79b6-4f20-a1a6-8277a6d7c6d8" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Birthdate", "CreatedBy", "DateCreated", "DateUpdated", "Gender", "Interest", "Location", "Occupation", "Picture", "UpdatedBy", "UserID", "UserName" },
                values: new object[,]
                {
                    { 1, "1990-01-15", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "Hiking, Reading", "Yishun", "Doctor", "/images/Profiles/ProfilePic1(300x300)", null, 0, "LeeSirui" },
                    { 2, "1985-08-22", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", "Traveling, Photography", "Bedok", "Marketing Specialist", "/images/Profiles/ProfilePic2(300x300)", null, 0, "Harith" },
                    { 3, "1992-04-05", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "Sports, Music", "PasirRis", "Teacher", "/images/Profiles/ProfilePic3(300x300)", null, 0, "Gerald" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Profiles_UserID1Id",
                table: "Matches",
                column: "UserID1Id",
                principalTable: "Profiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Profiles_UserID2Id",
                table: "Matches",
                column: "UserID2Id",
                principalTable: "Profiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Profiles_PUserNameId",
                table: "Posts",
                column: "PUserNameId",
                principalTable: "Profiles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Profiles_UserID1Id",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Profiles_UserID2Id",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Profiles_PUserNameId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Birthdate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Interest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Picture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3742b92-ff87-4abc-a087-42141379d7ac", "AQAAAAIAAYagAAAAEB8L0bvZWz3LXZrDBNcdEuGyFZ28A0lnDDdfG/16sNYBjgu8KMpfU46IolMlTIt+uA==", "8174d349-6564-4827-8b94-ffdaace05f6c" });

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Users_UserID1Id",
                table: "Matches",
                column: "UserID1Id",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Users_UserID2Id",
                table: "Matches",
                column: "UserID2Id",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_PUserNameId",
                table: "Posts",
                column: "PUserNameId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
