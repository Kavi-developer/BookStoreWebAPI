using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BooksStoreWebAPI.Models;

public partial class BookDbContext : DbContext
{
    public BookDbContext()
    {
    }

    public BookDbContext(DbContextOptions<BookDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookAuthor> BookAuthors { get; set; }

    public virtual DbSet<BookCategory> BookCategories { get; set; }

    public virtual DbSet<Configuration> Configurations { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<EmailSendList> EmailSendLists { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<File> Files { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    public virtual DbSet<PurchaseDetail> PurchaseDetails { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RoleRight> RoleRights { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<SaleDetail> SaleDetails { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=10.1.12.127;Initial Catalog=MG5_FW_BookStore;Integrated Security=True;Trust Server Certificate=True;Trusted_Connection=True;MultipleActiveResultSets=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasIndex(e => e.EmployeeId, "IX_Addresses_EmployeeId");

            entity.HasOne(d => d.Employee).WithMany(p => p.Addresses).HasForeignKey(d => d.EmployeeId);
        });

        modelBuilder.Entity<Author>(entity =>
        {
            entity.ToTable("Author");

            entity.Property(e => e.AuthorName).HasMaxLength(50);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.ToTable("Book");

            entity.Property(e => e.Inventory).HasDefaultValue(0);
            entity.Property(e => e.Isbn)
                .HasMaxLength(50)
                .HasColumnName("ISBN");

            entity.Property(e => e.PublisherName).HasMaxLength(50);
            entity.Property(e => e.SellingPrice).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Title).HasMaxLength(50);
            entity.Property(e => e.Url)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("url");

            entity.HasOne(d => d.BookCategory).WithMany(p => p.Books)
                .HasForeignKey(d => d.BookCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Book_BookCategory");
        });

        modelBuilder.Entity<BookAuthor>(entity =>
        {
            entity.ToTable("BookAuthor");

            entity.HasOne(d => d.Author).WithMany(p => p.BookAuthors)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BookAuthor_Author");

            entity.HasOne(d => d.Book).WithMany(p => p.BookAuthors)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BookAuthor_Book");
        });

        modelBuilder.Entity<BookCategory>(entity =>
        {
            entity.ToTable("BookCategory");

            entity.Property(e => e.BookCategoryName).HasMaxLength(50);
        });

        modelBuilder.Entity<Configuration>(entity =>
        {
            entity.ToTable("Configuration");

            entity.Property(e => e.Key).HasMaxLength(50);
            entity.Property(e => e.Value)
                .HasMaxLength(200)
                .HasColumnName("value");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.ToTable("Contact");

            entity.Property(e => e.AddressLine1).HasMaxLength(50);
            entity.Property(e => e.AddressLine2).HasMaxLength(50);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.ContactName).HasMaxLength(50);
            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.PhoneNo).HasMaxLength(50);
            entity.Property(e => e.State).HasMaxLength(50);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.Property(e => e.CustomerName).HasMaxLength(50);

            entity.HasOne(d => d.Contact).WithMany(p => p.Customers)
                .HasForeignKey(d => d.ContactId)
                .HasConstraintName("FK_Customer_Contact");
        });

        modelBuilder.Entity<EmailSendList>(entity =>
        {
            entity.ToTable("EmailSendList");

            entity.Property(e => e.Attachment)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Body).IsUnicode(false);
            entity.Property(e => e.EmailFrom)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EmailToList)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.IsHtml).HasDefaultValue(true);
            entity.Property(e => e.Subject)
                .HasMaxLength(2000)
                .IsUnicode(false);
        });

        modelBuilder.Entity<File>(entity =>
        {
            entity.ToTable("File");

            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Location).HasMaxLength(100);
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.ToTable("Menu");

            entity.Property(e => e.MenuText).HasMaxLength(50);
            entity.Property(e => e.Url).HasMaxLength(500);
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.ToTable("Purchase");

            entity.Property(e => e.DiscountAmount).HasColumnType("decimal(7, 2)");
            entity.Property(e => e.InvoiceAmount).HasColumnType("decimal(7, 2)");
            entity.Property(e => e.InvoiceNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.InvoiceUrl)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.SalesTax).HasColumnType("decimal(7, 2)");

            entity.HasOne(d => d.Vendor).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.VendorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Purchase_Vendor");
        });

        modelBuilder.Entity<PurchaseDetail>(entity =>
        {
            entity.ToTable("PurchaseDetail");

            entity.Property(e => e.Amount).HasColumnType("decimal(7, 2)");
            entity.Property(e => e.Rate).HasColumnType("decimal(7, 2)");

            entity.HasOne(d => d.Book).WithMany(p => p.PurchaseDetails)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PurchaseDetail_Book");

            entity.HasOne(d => d.Purchase).WithMany(p => p.PurchaseDetails)
                .HasForeignKey(d => d.PurchaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PurchaseDetail_Purchase");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<RoleRight>(entity =>
        {
            entity.ToTable("RoleRight");

            entity.Property(e => e.Right).HasMaxLength(20);

            entity.HasOne(d => d.Menu).WithMany(p => p.RoleRights)
                .HasForeignKey(d => d.MenuId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoleRight_Menu");

            entity.HasOne(d => d.Role).WithMany(p => p.RoleRights)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoleRight_Role");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.ToTable("Sale");

            entity.Property(e => e.DiscountAmount).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.InvoiceAmount).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.SalesTax).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.Customer).WithMany(p => p.Sales)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sale_Customer");
        });

        modelBuilder.Entity<SaleDetail>(entity =>
        {
            entity.ToTable("SaleDetail");

            entity.Property(e => e.Amount).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Rate).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.Book).WithMany(p => p.SaleDetails)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SaleDetail_Book");

            entity.HasOne(d => d.Sale).WithMany(p => p.SaleDetails)
                .HasForeignKey(d => d.SaleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SaleDetail_Sale");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName).HasMaxLength(50);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_User_Role");
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.ToTable("Vendor");

            entity.Property(e => e.VendorName).HasMaxLength(50);

            entity.HasOne(d => d.Contact).WithMany(p => p.Vendors)
                .HasForeignKey(d => d.ContactId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vendor_Contact");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
