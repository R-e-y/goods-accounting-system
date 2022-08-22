using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


#nullable disable

namespace MySite.Domain.Entities
{
    public class ProductionContext : IdentityDbContext <ApplicationUser>
    {
        

        public ProductionContext(DbContextOptions<ProductionContext> options) : base(options){}

        public virtual DbSet<Budget> Budgets { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual DbSet<FinishedProd> FinishedProds { get; set; }
        public virtual DbSet<Ingridient> Ingredients { get; set; }
        public virtual DbSet<Manufacture> Manufactures { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<ProdSale> ProdSales { get; set; }
        public virtual DbSet<Raw> Raws { get; set; }
        public virtual DbSet<RawPurchase> RawPurchases { get; set; }
        public virtual DbSet<Unit> Units { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Budget>(entity =>
            {
                entity.HasKey(e => e.IdBudget);

                entity.ToTable("Budget");

                entity.Property(e => e.IdBudget).HasColumnName("ID_budget");

                entity.Property(e => e.Sum)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("sum");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEmpl)
                    .HasName("PK_Employee");

                entity.Property(e => e.IdEmpl).HasColumnName("ID_empl");

                entity.Property(e => e.Address)
                    .HasMaxLength(30)
                    .HasColumnName("address")
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .HasMaxLength(60)
                    .HasColumnName("name")
                    .IsFixedLength(true);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .HasColumnName("phone")
                    .IsFixedLength(true);

                entity.Property(e => e.Post).HasColumnName("post");

                entity.Property(e => e.Premium)
                    .HasColumnName("premium")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Salary)
                    .HasColumnName("salary")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.PostNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.Post)
                    .HasConstraintName("FK_Employee_Post");
            });

            modelBuilder.Entity<Expense>(entity =>
            {
                entity.HasKey(e => e.IdExp);

                entity.Property(e => e.IdExp).HasColumnName("ID_exp");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");               

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name")
                    .IsFixedLength(true);

                entity.Property(e => e.Sum).HasColumnName("sum");

                entity.Property(e => e.Employee).HasColumnName("employee");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.Expenses)
                    .HasForeignKey(d => d.Employee)
                    .HasConstraintName("FK_Expense_Employee");


            });

            modelBuilder.Entity<FinishedProd>(entity =>
            {
                entity.HasKey(e => e.IdProd)
                    .HasName("PK_FinishedProd");

                entity.Property(e => e.IdProd).HasColumnName("ID_prod");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Markup)
                    .HasColumnName("markup")
                    .HasDefaultValueSql("((25))");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name")
                    .IsFixedLength(true);

                entity.Property(e => e.Price)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("price")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Unit).HasColumnName("unit");

                entity.HasOne(d => d.UnitNavigation)
                    .WithMany(p => p.FinishedProds)
                    .HasForeignKey(d => d.Unit)
                    .HasConstraintName("FK_FinishedProd_Unit");
            });

            modelBuilder.Entity<Ingridient>(entity =>
            {
                entity.HasKey(e => e.IdIngr)
                    .HasName("PK_Ingredient");

                entity.Property(e => e.IdIngr).HasColumnName("ID_ingr");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Product).HasColumnName("product");

                entity.Property(e => e.Raw).HasColumnName("raw");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.Ingredients)
                    .HasForeignKey(d => d.Product)
                    .HasConstraintName("FK_Ingredient_FinishedProd");

                entity.HasOne(d => d.RawNavigation)
                    .WithMany(p => p.Ingredients)
                    .HasForeignKey(d => d.Raw)
                    .HasConstraintName("FK_Ingredient_Raw");
            });

            modelBuilder.Entity<Manufacture>(entity =>
            {
                entity.HasKey(e => e.IdMan)
                    .HasName("PK_Manufacture");

                entity.Property(e => e.IdMan).HasColumnName("ID_man");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Employee).HasColumnName("employee");

                entity.Property(e => e.Product).HasColumnName("product");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.Manufactures)
                    .HasForeignKey(d => d.Employee)
                    .HasConstraintName("FK_Manufacture_Employee");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.Manufactures)
                    .HasForeignKey(d => d.Product)
                    .HasConstraintName("FK_Manufacture_FinishedProd");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.IdPost)
                    .HasName("PK_Post");

                entity.Property(e => e.IdPost).HasColumnName("ID_post");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<ProdSale>(entity =>
            {
                entity.HasKey(e => e.IdSale)
                    .HasName("PK_ProdSale");

                entity.Property(e => e.IdSale).HasColumnName("ID_sale");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Employee).HasColumnName("employee");

                entity.Property(e => e.Product).HasColumnName("product");

                entity.Property(e => e.Sum).HasColumnName("sum");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.ProdSales)
                    .HasForeignKey(d => d.Employee)
                    .HasConstraintName("FK_ProdSale_Employee");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.ProdSales)
                    .HasForeignKey(d => d.Product)
                    .HasConstraintName("FK_ProdSale_FinishedProd");
            });

            modelBuilder.Entity<Raw>(entity =>
            {
                entity.HasKey(e => e.IdRaw)
                    .HasName("PK_Raw");

                entity.Property(e => e.IdRaw).HasColumnName("ID_raw");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name")
                    .IsFixedLength(true);

                entity.Property(e => e.Sum).HasColumnName("sum");

                entity.Property(e => e.Unit).HasColumnName("unit");

                entity.HasOne(d => d.UnitNavigation)
                    .WithMany(p => p.Raws)
                    .HasForeignKey(d => d.Unit)
                    .HasConstraintName("FK_Raw_Unit");
            });

            modelBuilder.Entity<RawPurchase>(entity =>
            {
                entity.HasKey(e => e.IdPur)
                    .HasName("PK_RawPurchase");

                entity.Property(e => e.IdPur).HasColumnName("ID_pur");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Employee).HasColumnName("employee");

                entity.Property(e => e.Raw).HasColumnName("raw");

                entity.Property(e => e.Sum).HasColumnName("sum");

                entity.Property(e => e.Unit).HasColumnName("unit");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.RawPurchases)
                    .HasForeignKey(d => d.Employee)
                    .HasConstraintName("FK_RawPurchase_Employee");

                entity.HasOne(d => d.RawNavigation)
                    .WithMany(p => p.RawPurchases)
                    .HasForeignKey(d => d.Raw)
                    .HasConstraintName("FK_RawPurchase_Raw");

                entity.HasOne(d => d.UnitNavigation)
                    .WithMany(p => p.RawPurchases)
                    .HasForeignKey(d => d.Unit)
                    .HasConstraintName("FK_RawPurchase_Unit");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.HasKey(e => e.IdUnit)
                    .HasName("PK_Unit");

                entity.Property(e => e.IdUnit).HasColumnName("ID_unit");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name")
                    .IsFixedLength(true);
            });

            //OnModelCreatingPartial(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
