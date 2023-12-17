using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CrisprOutViewModels",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sequence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GRNA = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "DataSet",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepositoryURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Licenses = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Accuracy = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSet", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DNASequence",
                columns: table => new
                {
                    Sequence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataSetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.id);
                    table.ForeignKey(
                        name: "FK_Comment_DataSet_DataSetId",
                        column: x => x.DataSetId,
                        principalTable: "DataSet",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Model",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepositoryURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Licenses = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Accuracy = table.Column<float>(type: "real", nullable: true),
                    FileURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataSetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model", x => x.id);
                    table.ForeignKey(
                        name: "FK_Model_DataSet_DataSetId",
                        column: x => x.DataSetId,
                        principalTable: "DataSet",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Prop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prop_DataSet_ModelId",
                        column: x => x.ModelId,
                        principalTable: "DataSet",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataSetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tag_DataSet_DataSetId",
                        column: x => x.DataSetId,
                        principalTable: "DataSet",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_DataSetId",
                table: "Comment",
                column: "DataSetId");

            migrationBuilder.CreateIndex(
                name: "IX_Model_DataSetId",
                table: "Model",
                column: "DataSetId");

            migrationBuilder.CreateIndex(
                name: "IX_Prop_ModelId",
                table: "Prop",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_DataSetId",
                table: "Tag",
                column: "DataSetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "CrisprOutViewModels");

            migrationBuilder.DropTable(
                name: "DNASequence");

            migrationBuilder.DropTable(
                name: "Model");

            migrationBuilder.DropTable(
                name: "Prop");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "DataSet");
        }
    }
}
