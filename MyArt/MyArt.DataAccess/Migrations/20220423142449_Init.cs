using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyArt.DataAccess.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArtForm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtForm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exhibition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnnounceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ShareCount = table.Column<int>(type: "int", nullable: true),
                    Visible = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Moderation = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Announcement = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Release = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exhibition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Film",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Producer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShareCount = table.Column<int>(type: "int", nullable: true),
                    Visible = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Announcement = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Release = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExhibitionToArtForm",
                columns: table => new
                {
                    ExhibitionId = table.Column<int>(type: "int", nullable: false),
                    ArtFormId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExhibitionToArtForm", x => new { x.ExhibitionId, x.ArtFormId });
                    table.ForeignKey(
                        name: "FK_ExhibitionToArtForm_ArtForm_ArtFormId",
                        column: x => x.ArtFormId,
                        principalTable: "ArtForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExhibitionToArtForm_Exhibition_ExhibitionId",
                        column: x => x.ExhibitionId,
                        principalTable: "Exhibition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreToFilm",
                columns: table => new
                {
                    FilmId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreToFilm", x => new { x.FilmId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_GenreToFilm_Film_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Film",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreToFilm_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Art",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrightColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MutedColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DarkColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShareCount = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: true),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SellingAvailability = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Visible = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Moderation = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 4, 23, 17, 24, 49, 211, DateTimeKind.Local).AddTicks(2993)),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Art", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Art_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Board",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visible = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    ShareCount = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 4, 23, 17, 24, 49, 212, DateTimeKind.Local).AddTicks(6290)),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Board", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Board_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoughtFilms",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FilmId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoughtFilms", x => new { x.FilmId, x.UserId });
                    table.ForeignKey(
                        name: "FK_BoughtFilms_Film_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Film",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoughtFilms_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExhibitionComments",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ExhibitionId = table.Column<int>(type: "int", nullable: false),
                    CommentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExhibitionComments", x => new { x.UserId, x.ExhibitionId, x.CommentId });
                    table.ForeignKey(
                        name: "FK_ExhibitionComments_Comment_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExhibitionComments_Exhibition_ExhibitionId",
                        column: x => x.ExhibitionId,
                        principalTable: "Exhibition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExhibitionComments_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmComments",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FilmId = table.Column<int>(type: "int", nullable: false),
                    CommentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmComments", x => new { x.UserId, x.FilmId, x.CommentId });
                    table.ForeignKey(
                        name: "FK_FilmComments_Comment_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FilmComments_Film_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Film",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmComments_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LikeExhibitions",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ExhibitionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikeExhibitions", x => new { x.UserId, x.ExhibitionId });
                    table.ForeignKey(
                        name: "FK_LikeExhibitions_Exhibition_ExhibitionId",
                        column: x => x.ExhibitionId,
                        principalTable: "Exhibition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LikeExhibitions_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LikeFilms",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FilmId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikeFilms", x => new { x.UserId, x.FilmId });
                    table.ForeignKey(
                        name: "FK_LikeFilms_Film_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Film",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LikeFilms_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleToUser",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleToUser", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_RoleToUser_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleToUser_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtComments",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ArtId = table.Column<int>(type: "int", nullable: false),
                    CommentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtComments", x => new { x.UserId, x.ArtId, x.CommentId });
                    table.ForeignKey(
                        name: "FK_ArtComments_Art_ArtId",
                        column: x => x.ArtId,
                        principalTable: "Art",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtComments_Comment_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtComments_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ArtFormToArt",
                columns: table => new
                {
                    ArtFormId = table.Column<int>(type: "int", nullable: false),
                    ArtId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtFormToArt", x => new { x.ArtFormId, x.ArtId });
                    table.ForeignKey(
                        name: "FK_ArtFormToArt_Art_ArtId",
                        column: x => x.ArtId,
                        principalTable: "Art",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtFormToArt_ArtForm_ArtFormId",
                        column: x => x.ArtFormId,
                        principalTable: "ArtForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExhibitionToArt",
                columns: table => new
                {
                    ExhibitionId = table.Column<int>(type: "int", nullable: false),
                    ArtId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExhibitionToArt", x => new { x.ExhibitionId, x.ArtId });
                    table.ForeignKey(
                        name: "FK_ExhibitionToArt_Art_ArtId",
                        column: x => x.ArtId,
                        principalTable: "Art",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExhibitionToArt_Exhibition_ExhibitionId",
                        column: x => x.ExhibitionId,
                        principalTable: "Exhibition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LikeArts",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ArtId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikeArts", x => new { x.UserId, x.ArtId });
                    table.ForeignKey(
                        name: "FK_LikeArts_Art_ArtId",
                        column: x => x.ArtId,
                        principalTable: "Art",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LikeArts_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ArtFormToBoard",
                columns: table => new
                {
                    ArtFormId = table.Column<int>(type: "int", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtFormToBoard", x => new { x.ArtFormId, x.BoardId });
                    table.ForeignKey(
                        name: "FK_ArtFormToBoard_ArtForm_ArtFormId",
                        column: x => x.ArtFormId,
                        principalTable: "ArtForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtFormToBoard_Board_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Board",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtToBoard",
                columns: table => new
                {
                    ArtId = table.Column<int>(type: "int", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtToBoard", x => new { x.BoardId, x.ArtId });
                    table.ForeignKey(
                        name: "FK_ArtToBoard_Art_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Art",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtToBoard_Board_ArtId",
                        column: x => x.ArtId,
                        principalTable: "Board",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LikeBoards",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikeBoards", x => new { x.UserId, x.BoardId });
                    table.ForeignKey(
                        name: "FK_LikeBoards_Board_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Board",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LikeBoards_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Art_UserId",
                table: "Art",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtComments_ArtId",
                table: "ArtComments",
                column: "ArtId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtComments_CommentId",
                table: "ArtComments",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtFormToArt_ArtId",
                table: "ArtFormToArt",
                column: "ArtId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtFormToBoard_BoardId",
                table: "ArtFormToBoard",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtToBoard_ArtId",
                table: "ArtToBoard",
                column: "ArtId");

            migrationBuilder.CreateIndex(
                name: "IX_Board_UserId",
                table: "Board",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BoughtFilms_UserId",
                table: "BoughtFilms",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExhibitionComments_CommentId",
                table: "ExhibitionComments",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_ExhibitionComments_ExhibitionId",
                table: "ExhibitionComments",
                column: "ExhibitionId");

            migrationBuilder.CreateIndex(
                name: "IX_ExhibitionToArt_ArtId",
                table: "ExhibitionToArt",
                column: "ArtId");

            migrationBuilder.CreateIndex(
                name: "IX_ExhibitionToArtForm_ArtFormId",
                table: "ExhibitionToArtForm",
                column: "ArtFormId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmComments_CommentId",
                table: "FilmComments",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmComments_FilmId",
                table: "FilmComments",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreToFilm_GenreId",
                table: "GenreToFilm",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_LikeArts_ArtId",
                table: "LikeArts",
                column: "ArtId");

            migrationBuilder.CreateIndex(
                name: "IX_LikeBoards_BoardId",
                table: "LikeBoards",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_LikeExhibitions_ExhibitionId",
                table: "LikeExhibitions",
                column: "ExhibitionId");

            migrationBuilder.CreateIndex(
                name: "IX_LikeFilms_FilmId",
                table: "LikeFilms",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleToUser_RoleId",
                table: "RoleToUser",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtComments");

            migrationBuilder.DropTable(
                name: "ArtFormToArt");

            migrationBuilder.DropTable(
                name: "ArtFormToBoard");

            migrationBuilder.DropTable(
                name: "ArtToBoard");

            migrationBuilder.DropTable(
                name: "BoughtFilms");

            migrationBuilder.DropTable(
                name: "ExhibitionComments");

            migrationBuilder.DropTable(
                name: "ExhibitionToArt");

            migrationBuilder.DropTable(
                name: "ExhibitionToArtForm");

            migrationBuilder.DropTable(
                name: "FilmComments");

            migrationBuilder.DropTable(
                name: "GenreToFilm");

            migrationBuilder.DropTable(
                name: "LikeArts");

            migrationBuilder.DropTable(
                name: "LikeBoards");

            migrationBuilder.DropTable(
                name: "LikeExhibitions");

            migrationBuilder.DropTable(
                name: "LikeFilms");

            migrationBuilder.DropTable(
                name: "RoleToUser");

            migrationBuilder.DropTable(
                name: "ArtForm");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Art");

            migrationBuilder.DropTable(
                name: "Board");

            migrationBuilder.DropTable(
                name: "Exhibition");

            migrationBuilder.DropTable(
                name: "Film");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
