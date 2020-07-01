using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Courses.EfDataAccess.Migrations
{
    public partial class InitialTableAndData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    LastName = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Duration = table.Column<string>(nullable: false),
                    VideoLink = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: false),
                    TeacherId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Courses_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lectures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    CoursId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lectures_Courses_CoursId",
                        column: x => x.CoursId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "IsActive", "IsDeleted", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 6, 27, 22, 20, 32, 211, DateTimeKind.Local).AddTicks(1617), null, false, false, null, "Operating Systems" },
                    { 2, new DateTime(2020, 6, 27, 22, 20, 32, 529, DateTimeKind.Local).AddTicks(6746), null, false, false, null, "Frontend" },
                    { 3, new DateTime(2020, 6, 27, 22, 20, 32, 529, DateTimeKind.Local).AddTicks(6912), null, false, false, null, "Backend" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "FirstName", "IsActive", "IsDeleted", "LastName", "ModifiedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Anna", false, false, "Boss", null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Michael", false, false, "Smith", null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Stella", false, false, "Williams", null },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nick", false, false, "Davis", null }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "DeletedAt", "Description", "Duration", "Image", "IsActive", "IsDeleted", "ModifiedAt", "Name", "TeacherId", "VideoLink" },
                values: new object[,]
                {
                    { 4, 1, new DateTime(2020, 6, 27, 22, 20, 32, 531, DateTimeKind.Local).AddTicks(2823), null, "Windows Server 2016 is the most recent version of Microsoft's server technology, offering multiple benefits over previous versions, including better security, consistent identity management, built-in support for containers, deployment features for the cloud, and much more. It's the next-gen server for developers, and this course has been designed to help you understand all things Windows Server 2016.", "1 hour 15 minutes", "windows.jpg", false, false, null, "Windows Server 2016", 1, "https://www.youtube.com/watch?v=hZ2QiiHyTnU" },
                    { 2, 3, new DateTime(2020, 6, 27, 22, 20, 32, 531, DateTimeKind.Local).AddTicks(2665), null, "PHP and MySQL are two important tools used in web development, allowing you to create interactive content that integrates with databases to manage large amounts of data. Learning both will help you create login pages, check details from a form, create forums, restrict user access to certain pages, and much more. Your websites will have considerably more functionality, and you can leverage the knowledge you gain in this course into high-paying web development jobs.", "4 hour 36 minutes", "php.jpg", false, false, null, "PHP and MySQL", 2, "https://www.youtube.com/watch?v=OK_JCtrrv-c" },
                    { 1, 1, new DateTime(2020, 6, 27, 22, 20, 32, 530, DateTimeKind.Local).AddTicks(6303), null, "Linux and UNIX operating systems have become increasingly popular in commercial computing environments. Due to their rapid growth in today's businesses, Linux/UNIX administrators have also become very much in-demand. This hands-on duo of courses will help you prepare for the CompTIA Linux+ and the Novell Certified Linux Professional certification exams, thus improving your chances of scoring a big income working with Linux.", "2 hour 34 minutes", "linux.jpg", false, false, null, "Linux/UNIX Certification Training Bundle", 3, "https://www.youtube.com/watch?v=v_1zB2WNN14" },
                    { 3, 2, new DateTime(2020, 6, 27, 22, 20, 32, 531, DateTimeKind.Local).AddTicks(2809), null, "JavaScript is the language that powers the internet and if you want to build websites, you have to know JavaScript. This course delivers everything you need to get started with JavaScript and will help you build and apply 50 projects and challenges.", "3 hour 26 minutes", "javaScript.jpg", false, false, null, "Complete Introduction to JavaScript", 4, "https://www.youtube.com/watch?v=PkZNo7MFNFg" }
                });

            migrationBuilder.InsertData(
                table: "Lectures",
                columns: new[] { "Id", "CoursId", "CreatedAt", "DeletedAt", "IsActive", "IsDeleted", "ModifiedAt", "Title" },
                values: new object[,]
                {
                    { 12, 4, new DateTime(2020, 6, 27, 22, 20, 32, 531, DateTimeKind.Local).AddTicks(6022), null, false, false, null, "Introduction to practical Windows system management" },
                    { 13, 4, new DateTime(2020, 6, 27, 22, 20, 32, 531, DateTimeKind.Local).AddTicks(6029), null, false, false, null, "Users and authentication in a Windows environment" },
                    { 14, 4, new DateTime(2020, 6, 27, 22, 20, 32, 531, DateTimeKind.Local).AddTicks(6036), null, false, false, null, "Securing Windows in the enterprise" },
                    { 5, 2, new DateTime(2020, 6, 27, 22, 20, 32, 531, DateTimeKind.Local).AddTicks(5963), null, false, false, null, "Section 1: Introduction" },
                    { 6, 2, new DateTime(2020, 6, 27, 22, 20, 32, 531, DateTimeKind.Local).AddTicks(5975), null, false, false, null, "Section 2: Important Concepts in PHP" },
                    { 7, 2, new DateTime(2020, 6, 27, 22, 20, 32, 531, DateTimeKind.Local).AddTicks(5984), null, false, false, null, "Section 3: Advanced Concepts in PHP" },
                    { 8, 2, new DateTime(2020, 6, 27, 22, 20, 32, 531, DateTimeKind.Local).AddTicks(5991), null, false, false, null, "Section 4: Expertise In PHP and MySQL" },
                    { 1, 1, new DateTime(2020, 6, 27, 22, 20, 32, 531, DateTimeKind.Local).AddTicks(3996), null, false, false, null, "Mod 1: Instructions" },
                    { 2, 1, new DateTime(2020, 6, 27, 22, 20, 32, 531, DateTimeKind.Local).AddTicks(5793), null, false, false, null, "Mod 2: Managing Softwer" },
                    { 3, 1, new DateTime(2020, 6, 27, 22, 20, 32, 531, DateTimeKind.Local).AddTicks(5944), null, false, false, null, "Mod 3: Managing Files" },
                    { 4, 1, new DateTime(2020, 6, 27, 22, 20, 32, 531, DateTimeKind.Local).AddTicks(5955), null, false, false, null, "Mod 4: Managing Hardwer" },
                    { 9, 3, new DateTime(2020, 6, 27, 22, 20, 32, 531, DateTimeKind.Local).AddTicks(5998), null, false, false, null, "Lecture 1: Core JavaScript introduction" },
                    { 10, 3, new DateTime(2020, 6, 27, 22, 20, 32, 531, DateTimeKind.Local).AddTicks(6007), null, false, false, null, "Lecture 2: JavaScript DOM and dynamic web pages with JavaScript" },
                    { 11, 3, new DateTime(2020, 6, 27, 22, 20, 32, 531, DateTimeKind.Local).AddTicks(6015), null, false, false, null, "Lecture 3: JavaScript Advanced and dynamic web applications" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CategoryId",
                table: "Courses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Name",
                table: "Courses",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TeacherId",
                table: "Courses",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_CoursId",
                table: "Lectures",
                column: "CoursId");

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_Title",
                table: "Lectures",
                column: "Title",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lectures");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
