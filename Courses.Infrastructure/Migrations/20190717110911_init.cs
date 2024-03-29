﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Courses.Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuthorName = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<string>(maxLength: 100, nullable: true),
                    UpdateOn = table.Column<DateTime>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseName = table.Column<string>(maxLength: 50, nullable: true),
                    CourseCategory = table.Column<string>(maxLength: 50, nullable: true),
                    AuthorId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateOn = table.Column<DateTime>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Courses_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "AuthorName", "CreatedBy", "CreatedOn", "IsDelete", "UpdateBy", "UpdateOn" },
                values: new object[] { 1, "Alaa Altair", null, new DateTime(2019, 7, 17, 14, 9, 11, 211, DateTimeKind.Local), false, null, null });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "AuthorName", "CreatedBy", "CreatedOn", "IsDelete", "UpdateBy", "UpdateOn" },
                values: new object[] { 2, "Ali Altair", null, new DateTime(2019, 7, 17, 14, 9, 11, 220, DateTimeKind.Local), false, null, null });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "AuthorName", "CreatedBy", "CreatedOn", "IsDelete", "UpdateBy", "UpdateOn" },
                values: new object[] { 3, "Ahmad Altair", null, new DateTime(2019, 7, 17, 14, 9, 11, 220, DateTimeKind.Local), false, null, null });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "AuthorId", "CourseCategory", "CourseName", "CreatedBy", "CreatedOn", "IsDelete", "UpdateBy", "UpdateOn" },
                values: new object[] { 1, 1, "FullStack", ".Net Core With React", null, new DateTime(2019, 7, 17, 14, 9, 11, 220, DateTimeKind.Local), false, null, null });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "AuthorId", "CourseCategory", "CourseName", "CreatedBy", "CreatedOn", "IsDelete", "UpdateBy", "UpdateOn" },
                values: new object[] { 2, 2, "FrontEnd", "React With Redux", null, new DateTime(2019, 7, 17, 14, 9, 11, 220, DateTimeKind.Local), false, null, null });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "AuthorId", "CourseCategory", "CourseName", "CreatedBy", "CreatedOn", "IsDelete", "UpdateBy", "UpdateOn" },
                values: new object[] { 3, 3, "BackEnd", ".Net Core WebApi", null, new DateTime(2019, 7, 17, 14, 9, 11, 220, DateTimeKind.Local), false, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_AuthorId",
                table: "Courses",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
