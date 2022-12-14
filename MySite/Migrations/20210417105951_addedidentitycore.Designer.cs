// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MySite.Domain.Entities;

namespace MySite.Migrations
{
    [DbContext(typeof(ProductionContext))]
    [Migration("20210417105951_addedidentitycore")]
    partial class addedidentitycore
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("MySite.Domain.Entities.Budget", b =>
                {
                    b.Property<int>("IdBudget")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_budget")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("Sum")
                        .HasColumnType("numeric(18,2)")
                        .HasColumnName("sum");

                    b.HasKey("IdBudget");

                    b.ToTable("Budget");
                });

            modelBuilder.Entity("MySite.Domain.Entities.Employee", b =>
                {
                    b.Property<int>("IdEmpl")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_empl")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(30)
                        .HasColumnType("nchar(30)")
                        .HasColumnName("address")
                        .IsFixedLength(true);

                    b.Property<string>("Name")
                        .HasMaxLength(60)
                        .HasColumnType("nchar(60)")
                        .HasColumnName("name")
                        .IsFixedLength(true);

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("nchar(20)")
                        .HasColumnName("phone")
                        .IsFixedLength(true);

                    b.Property<int?>("Post")
                        .HasColumnType("int")
                        .HasColumnName("post");

                    b.Property<int?>("Premium")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("premium")
                        .HasDefaultValueSql("((0))");

                    b.Property<int?>("Salary")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("salary")
                        .HasDefaultValueSql("((0))");

                    b.HasKey("IdEmpl")
                        .HasName("PK_Employee");

                    b.HasIndex("Post");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("MySite.Domain.Entities.Expense", b =>
                {
                    b.Property<int>("IdExp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_exp")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Date")
                        .HasColumnType("date")
                        .HasColumnName("date");

                    b.Property<int?>("Employee")
                        .HasColumnType("int")
                        .HasColumnName("employee");

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .HasColumnType("nchar(30)")
                        .HasColumnName("name")
                        .IsFixedLength(true);

                    b.Property<int?>("Sum")
                        .HasColumnType("int")
                        .HasColumnName("sum");

                    b.HasKey("IdExp");

                    b.HasIndex("Employee");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("MySite.Domain.Entities.FinishedProd", b =>
                {
                    b.Property<int>("IdProd")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_prod")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Amount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("amount")
                        .HasDefaultValueSql("((0))");

                    b.Property<int?>("Markup")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("markup")
                        .HasDefaultValueSql("((25))");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nchar(50)")
                        .HasColumnName("name")
                        .IsFixedLength(true);

                    b.Property<decimal?>("Price")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(18,2)")
                        .HasColumnName("price")
                        .HasDefaultValueSql("((0))");

                    b.Property<int?>("Unit")
                        .HasColumnType("int")
                        .HasColumnName("unit");

                    b.HasKey("IdProd")
                        .HasName("PK_FinishedProd");

                    b.HasIndex("Unit");

                    b.ToTable("FinishedProds");
                });

            modelBuilder.Entity("MySite.Domain.Entities.Ingridient", b =>
                {
                    b.Property<int>("IdIngr")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_ingr")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Amount")
                        .HasColumnType("int")
                        .HasColumnName("amount");

                    b.Property<int?>("Product")
                        .HasColumnType("int")
                        .HasColumnName("product");

                    b.Property<int?>("Raw")
                        .HasColumnType("int")
                        .HasColumnName("raw");

                    b.HasKey("IdIngr")
                        .HasName("PK_Ingredient");

                    b.HasIndex("Product");

                    b.HasIndex("Raw");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("MySite.Domain.Entities.Manufacture", b =>
                {
                    b.Property<int>("IdMan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_man")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Amount")
                        .HasColumnType("int")
                        .HasColumnName("amount");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("date")
                        .HasColumnName("date");

                    b.Property<int?>("Employee")
                        .HasColumnType("int")
                        .HasColumnName("employee");

                    b.Property<int?>("Product")
                        .HasColumnType("int")
                        .HasColumnName("product");

                    b.HasKey("IdMan")
                        .HasName("PK_Manufacture");

                    b.HasIndex("Employee");

                    b.HasIndex("Product");

                    b.ToTable("Manufactures");
                });

            modelBuilder.Entity("MySite.Domain.Entities.Post", b =>
                {
                    b.Property<int>("IdPost")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_post")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.HasKey("IdPost")
                        .HasName("PK_Post");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("MySite.Domain.Entities.ProdSale", b =>
                {
                    b.Property<int>("IdSale")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_sale")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Amount")
                        .HasColumnType("int")
                        .HasColumnName("amount");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("date")
                        .HasColumnName("date");

                    b.Property<int?>("Employee")
                        .HasColumnType("int")
                        .HasColumnName("employee");

                    b.Property<int?>("Product")
                        .HasColumnType("int")
                        .HasColumnName("product");

                    b.Property<int?>("Sum")
                        .HasColumnType("int")
                        .HasColumnName("sum");

                    b.HasKey("IdSale")
                        .HasName("PK_ProdSale");

                    b.HasIndex("Employee");

                    b.HasIndex("Product");

                    b.ToTable("ProdSales");
                });

            modelBuilder.Entity("MySite.Domain.Entities.Raw", b =>
                {
                    b.Property<int>("IdRaw")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_raw")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Amount")
                        .HasColumnType("int")
                        .HasColumnName("amount");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nchar(50)")
                        .HasColumnName("name")
                        .IsFixedLength(true);

                    b.Property<int?>("Sum")
                        .HasColumnType("int")
                        .HasColumnName("sum");

                    b.Property<int?>("Unit")
                        .HasColumnType("int")
                        .HasColumnName("unit");

                    b.HasKey("IdRaw")
                        .HasName("PK_Raw");

                    b.HasIndex("Unit");

                    b.ToTable("Raws");
                });

            modelBuilder.Entity("MySite.Domain.Entities.RawPurchase", b =>
                {
                    b.Property<int>("IdPur")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_pur")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Amount")
                        .HasColumnType("int")
                        .HasColumnName("amount");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("date")
                        .HasColumnName("date");

                    b.Property<int?>("Employee")
                        .HasColumnType("int")
                        .HasColumnName("employee");

                    b.Property<int?>("Raw")
                        .HasColumnType("int")
                        .HasColumnName("raw");

                    b.Property<int?>("Sum")
                        .HasColumnType("int")
                        .HasColumnName("sum");

                    b.Property<int?>("Unit")
                        .HasColumnType("int")
                        .HasColumnName("unit");

                    b.HasKey("IdPur")
                        .HasName("PK_RawPurchase");

                    b.HasIndex("Employee");

                    b.HasIndex("Raw");

                    b.HasIndex("Unit");

                    b.ToTable("RawPurchases");
                });

            modelBuilder.Entity("MySite.Domain.Entities.Unit", b =>
                {
                    b.Property<int>("IdUnit")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_unit")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .HasColumnType("nchar(30)")
                        .HasColumnName("name")
                        .IsFixedLength(true);

                    b.HasKey("IdUnit")
                        .HasName("PK_Unit");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MySite.Domain.Entities.Employee", b =>
                {
                    b.HasOne("MySite.Domain.Entities.Post", "PostNavigation")
                        .WithMany("Employees")
                        .HasForeignKey("Post")
                        .HasConstraintName("FK_Employee_Post");

                    b.Navigation("PostNavigation");
                });

            modelBuilder.Entity("MySite.Domain.Entities.Expense", b =>
                {
                    b.HasOne("MySite.Domain.Entities.Employee", "EmployeeNavigation")
                        .WithMany("Expenses")
                        .HasForeignKey("Employee")
                        .HasConstraintName("FK_Expense_Employee");

                    b.Navigation("EmployeeNavigation");
                });

            modelBuilder.Entity("MySite.Domain.Entities.FinishedProd", b =>
                {
                    b.HasOne("MySite.Domain.Entities.Unit", "UnitNavigation")
                        .WithMany("FinishedProds")
                        .HasForeignKey("Unit")
                        .HasConstraintName("FK_FinishedProd_Unit");

                    b.Navigation("UnitNavigation");
                });

            modelBuilder.Entity("MySite.Domain.Entities.Ingridient", b =>
                {
                    b.HasOne("MySite.Domain.Entities.FinishedProd", "ProductNavigation")
                        .WithMany("Ingredients")
                        .HasForeignKey("Product")
                        .HasConstraintName("FK_Ingredient_FinishedProd");

                    b.HasOne("MySite.Domain.Entities.Raw", "RawNavigation")
                        .WithMany("Ingredients")
                        .HasForeignKey("Raw")
                        .HasConstraintName("FK_Ingredient_Raw");

                    b.Navigation("ProductNavigation");

                    b.Navigation("RawNavigation");
                });

            modelBuilder.Entity("MySite.Domain.Entities.Manufacture", b =>
                {
                    b.HasOne("MySite.Domain.Entities.Employee", "EmployeeNavigation")
                        .WithMany("Manufactures")
                        .HasForeignKey("Employee")
                        .HasConstraintName("FK_Manufacture_Employee");

                    b.HasOne("MySite.Domain.Entities.FinishedProd", "ProductNavigation")
                        .WithMany("Manufactures")
                        .HasForeignKey("Product")
                        .HasConstraintName("FK_Manufacture_FinishedProd");

                    b.Navigation("EmployeeNavigation");

                    b.Navigation("ProductNavigation");
                });

            modelBuilder.Entity("MySite.Domain.Entities.ProdSale", b =>
                {
                    b.HasOne("MySite.Domain.Entities.Employee", "EmployeeNavigation")
                        .WithMany("ProdSales")
                        .HasForeignKey("Employee")
                        .HasConstraintName("FK_ProdSale_Employee");

                    b.HasOne("MySite.Domain.Entities.FinishedProd", "ProductNavigation")
                        .WithMany("ProdSales")
                        .HasForeignKey("Product")
                        .HasConstraintName("FK_ProdSale_FinishedProd");

                    b.Navigation("EmployeeNavigation");

                    b.Navigation("ProductNavigation");
                });

            modelBuilder.Entity("MySite.Domain.Entities.Raw", b =>
                {
                    b.HasOne("MySite.Domain.Entities.Unit", "UnitNavigation")
                        .WithMany("Raws")
                        .HasForeignKey("Unit")
                        .HasConstraintName("FK_Raw_Unit");

                    b.Navigation("UnitNavigation");
                });

            modelBuilder.Entity("MySite.Domain.Entities.RawPurchase", b =>
                {
                    b.HasOne("MySite.Domain.Entities.Employee", "EmployeeNavigation")
                        .WithMany("RawPurchases")
                        .HasForeignKey("Employee")
                        .HasConstraintName("FK_RawPurchase_Employee");

                    b.HasOne("MySite.Domain.Entities.Raw", "RawNavigation")
                        .WithMany("RawPurchases")
                        .HasForeignKey("Raw")
                        .HasConstraintName("FK_RawPurchase_Raw");

                    b.HasOne("MySite.Domain.Entities.Unit", "UnitNavigation")
                        .WithMany("RawPurchases")
                        .HasForeignKey("Unit")
                        .HasConstraintName("FK_RawPurchase_Unit");

                    b.Navigation("EmployeeNavigation");

                    b.Navigation("RawNavigation");

                    b.Navigation("UnitNavigation");
                });

            modelBuilder.Entity("MySite.Domain.Entities.Employee", b =>
                {
                    b.Navigation("Expenses");

                    b.Navigation("Manufactures");

                    b.Navigation("ProdSales");

                    b.Navigation("RawPurchases");
                });

            modelBuilder.Entity("MySite.Domain.Entities.FinishedProd", b =>
                {
                    b.Navigation("Ingredients");

                    b.Navigation("Manufactures");

                    b.Navigation("ProdSales");
                });

            modelBuilder.Entity("MySite.Domain.Entities.Post", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("MySite.Domain.Entities.Raw", b =>
                {
                    b.Navigation("Ingredients");

                    b.Navigation("RawPurchases");
                });

            modelBuilder.Entity("MySite.Domain.Entities.Unit", b =>
                {
                    b.Navigation("FinishedProds");

                    b.Navigation("RawPurchases");

                    b.Navigation("Raws");
                });
#pragma warning restore 612, 618
        }
    }
}
