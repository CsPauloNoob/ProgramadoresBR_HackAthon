using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "guild",
                columns: table => new
                {
                    Id = table.Column<ulong>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    OwnerId = table.Column<ulong>(type: "INTEGER", nullable: false),
                    RankingTypes = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guild", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<ulong>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GameNickName = table.Column<string>(type: "TEXT", nullable: false),
                    DiscordNickName = table.Column<string>(type: "TEXT", nullable: false),
                    ThumbUrl = table.Column<string>(type: "TEXT", nullable: false),
                    IsRanked = table.Column<bool>(type: "INTEGER", nullable: false),
                    RankPoints = table.Column<int>(type: "INTEGER", nullable: false),
                    GuildId = table.Column<ulong>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_guild_GuildId",
                        column: x => x.GuildId,
                        principalTable: "guild",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "DiscordNickName", "GameNickName", "GuildId", "IsRanked", "RankPoints", "ThumbUrl" },
                values: new object[,]
                {
                    { 385869185198063626ul, "Cleiton Furst", "Jhpo", 1038639386646032415ul, true, 640, "https://cdn.discordapp.com/embed/avatars/0.png?size=1024" },
                    { 608124889064275968ul, "GabProgamer", "GabsProGamer", 1038639386646032415ul, true, 2, "https://cdn.discordapp.com/embed/avatars/0.png?size=1024" },
                    { 660962157457965068ul, "HaiKaiis", "haikaiis!", 1038639386646032415ul, true, 748, "https://cdn.discordapp.com/embed/avatars/0.png?size=1024" },
                    { 732999507331252246ul, "VicManzas", "manzass", 1038639386646032415ul, true, 117, "https://cdn.discordapp.com/embed/avatars/0.png?size=1024" },
                    { 926292122842312795ul, "camargooo", "Faker171", 1038639386646032415ul, true, 99, "https://cdn.discordapp.com/embed/avatars/0.png?size=1024" },
                    { 1134185785617293402ul, "yuru44", "Oyurii", 1038639386646032415ul, true, 47, "https://cdn.discordapp.com/embed/avatars/0.png?size=1024" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_GuildId",
                table: "user",
                column: "GuildId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "guild");
        }
    }
}
