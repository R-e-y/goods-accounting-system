using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MySite.Migrations
{
    public partial class addedidentitycore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "Budget",
            //    columns: table => new
            //    {
            //        ID_budget = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        sum = table.Column<decimal>(type: "numeric(18,2)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Budget", x => x.ID_budget);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Posts",
            //    columns: table => new
            //    {
            //        ID_post = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Post", x => x.ID_post);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Units",
            //    columns: table => new
            //    {
            //        ID_unit = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        name = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Unit", x => x.ID_unit);
            //    });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.CreateTable(
            //    name: "Employees",
            //    columns: table => new
            //    {
            //        ID_empl = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        name = table.Column<string>(type: "nchar(60)", fixedLength: true, maxLength: 60, nullable: true),
            //        post = table.Column<int>(type: "int", nullable: true),
            //        salary = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
            //        address = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: true),
            //        phone = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: true),
            //        premium = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Employee", x => x.ID_empl);
            //        table.ForeignKey(
            //            name: "FK_Employee_Post",
            //            column: x => x.post,
            //            principalTable: "Posts",
            //            principalColumn: "ID_post",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "FinishedProds",
            //    columns: table => new
            //    {
            //        ID_prod = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        name = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: true),
            //        unit = table.Column<int>(type: "int", nullable: true),
            //        price = table.Column<decimal>(type: "numeric(18,2)", nullable: true, defaultValueSql: "((0))"),
            //        amount = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
            //        markup = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((25))")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_FinishedProd", x => x.ID_prod);
            //        table.ForeignKey(
            //            name: "FK_FinishedProd_Unit",
            //            column: x => x.unit,
            //            principalTable: "Units",
            //            principalColumn: "ID_unit",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Raws",
            //    columns: table => new
            //    {
            //        ID_raw = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        name = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: true),
            //        unit = table.Column<int>(type: "int", nullable: true),
            //        sum = table.Column<int>(type: "int", nullable: true),
            //        amount = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Raw", x => x.ID_raw);
            //        table.ForeignKey(
            //            name: "FK_Raw_Unit",
            //            column: x => x.unit,
            //            principalTable: "Units",
            //            principalColumn: "ID_unit",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Expenses",
            //    columns: table => new
            //    {
            //        ID_exp = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        name = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: true),
            //        sum = table.Column<int>(type: "int", nullable: true),
            //        date = table.Column<DateTime>(type: "date", nullable: true),
            //        employee = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Expenses", x => x.ID_exp);
            //        table.ForeignKey(
            //            name: "FK_Expense_Employee",
            //            column: x => x.employee,
            //            principalTable: "Employees",
            //            principalColumn: "ID_empl",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Manufactures",
            //    columns: table => new
            //    {
            //        ID_man = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        product = table.Column<int>(type: "int", nullable: true),
            //        amount = table.Column<int>(type: "int", nullable: true),
            //        date = table.Column<DateTime>(type: "date", nullable: true),
            //        employee = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Manufacture", x => x.ID_man);
            //        table.ForeignKey(
            //            name: "FK_Manufacture_Employee",
            //            column: x => x.employee,
            //            principalTable: "Employees",
            //            principalColumn: "ID_empl",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Manufacture_FinishedProd",
            //            column: x => x.product,
            //            principalTable: "FinishedProds",
            //            principalColumn: "ID_prod",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ProdSales",
            //    columns: table => new
            //    {
            //        ID_sale = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        product = table.Column<int>(type: "int", nullable: true),
            //        amount = table.Column<int>(type: "int", nullable: true),
            //        sum = table.Column<int>(type: "int", nullable: true),
            //        date = table.Column<DateTime>(type: "date", nullable: true),
            //        employee = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ProdSale", x => x.ID_sale);
            //        table.ForeignKey(
            //            name: "FK_ProdSale_Employee",
            //            column: x => x.employee,
            //            principalTable: "Employees",
            //            principalColumn: "ID_empl",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_ProdSale_FinishedProd",
            //            column: x => x.product,
            //            principalTable: "FinishedProds",
            //            principalColumn: "ID_prod",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Ingredients",
            //    columns: table => new
            //    {
            //        ID_ingr = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        product = table.Column<int>(type: "int", nullable: true),
            //        raw = table.Column<int>(type: "int", nullable: true),
            //        amount = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Ingredient", x => x.ID_ingr);
            //        table.ForeignKey(
            //            name: "FK_Ingredient_FinishedProd",
            //            column: x => x.product,
            //            principalTable: "FinishedProds",
            //            principalColumn: "ID_prod",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Ingredient_Raw",
            //            column: x => x.raw,
            //            principalTable: "Raws",
            //            principalColumn: "ID_raw",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "RawPurchases",
            //    columns: table => new
            //    {
            //        ID_pur = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        raw = table.Column<int>(type: "int", nullable: true),
            //        amount = table.Column<int>(type: "int", nullable: true),
            //        sum = table.Column<int>(type: "int", nullable: true),
            //        unit = table.Column<int>(type: "int", nullable: true),
            //        date = table.Column<DateTime>(type: "date", nullable: true),
            //        employee = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_RawPurchase", x => x.ID_pur);
            //        table.ForeignKey(
            //            name: "FK_RawPurchase_Employee",
            //            column: x => x.employee,
            //            principalTable: "Employees",
            //            principalColumn: "ID_empl",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_RawPurchase_Raw",
            //            column: x => x.raw,
            //            principalTable: "Raws",
            //            principalColumn: "ID_raw",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_RawPurchase_Unit",
            //            column: x => x.unit,
            //            principalTable: "Units",
            //            principalColumn: "ID_unit",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Employees_post",
            //    table: "Employees",
            //    column: "post");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Expenses_employee",
            //    table: "Expenses",
            //    column: "employee");

            //migrationBuilder.CreateIndex(
            //    name: "IX_FinishedProds_unit",
            //    table: "FinishedProds",
            //    column: "unit");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Ingredients_product",
            //    table: "Ingredients",
            //    column: "product");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Ingredients_raw",
            //    table: "Ingredients",
            //    column: "raw");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Manufactures_employee",
            //    table: "Manufactures",
            //    column: "employee");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Manufactures_product",
            //    table: "Manufactures",
            //    column: "product");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProdSales_employee",
            //    table: "ProdSales",
            //    column: "employee");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProdSales_product",
            //    table: "ProdSales",
            //    column: "product");

            //migrationBuilder.CreateIndex(
            //    name: "IX_RawPurchases_employee",
            //    table: "RawPurchases",
            //    column: "employee");

            //migrationBuilder.CreateIndex(
            //    name: "IX_RawPurchases_raw",
            //    table: "RawPurchases",
            //    column: "raw");

            //migrationBuilder.CreateIndex(
            //    name: "IX_RawPurchases_unit",
            //    table: "RawPurchases",
            //    column: "unit");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Raws_unit",
            //    table: "Raws",
            //    column: "unit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            //migrationBuilder.DropTable(
            //    name: "Budget");

            //migrationBuilder.DropTable(
            //    name: "Expenses");

            //migrationBuilder.DropTable(
            //    name: "Ingredients");

            //migrationBuilder.DropTable(
            //    name: "Manufactures");

            //migrationBuilder.DropTable(
            //    name: "ProdSales");

            //migrationBuilder.DropTable(
            //    name: "RawPurchases");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            //migrationBuilder.DropTable(
            //    name: "FinishedProds");

            //migrationBuilder.DropTable(
            //    name: "Employees");

            //migrationBuilder.DropTable(
            //    name: "Raws");

            //migrationBuilder.DropTable(
            //    name: "Posts");

            //migrationBuilder.DropTable(
            //    name: "Units");
        }
    }
}
