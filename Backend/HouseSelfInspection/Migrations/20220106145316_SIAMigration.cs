﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseSelfInspection.Migrations
{
    public partial class SIAMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    HouseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    House_size = table.Column<string>(maxLength: 10, nullable: true),
                    House_type = table.Column<string>(maxLength: 25, nullable: true),
                    House_number = table.Column<string>(maxLength: 5, nullable: false),
                    Street = table.Column<string>(maxLength: 25, nullable: false),
                    Suburb = table.Column<string>(maxLength: 25, nullable: false),
                    State = table.Column<string>(maxLength: 25, nullable: false),
                    Postal_code = table.Column<string>(maxLength: 5, nullable: false),
                    ImgPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.HouseId);
                });

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    User_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    isAdmin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.User_ID);
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 25, nullable: false),
                    Contact = table.Column<string>(maxLength: 25, nullable: false),
                    Email = table.Column<string>(maxLength: 25, nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Username = table.Column<string>(maxLength: 25, nullable: false),
                    Password = table.Column<string>(maxLength: 25, nullable: false),
                    HouseId = table.Column<int>(nullable: false),
                    house_address = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tenants_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "HouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_HouseId",
                table: "Tenants",
                column: "HouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.DropTable(
                name: "Houses");
        }
    }
}
