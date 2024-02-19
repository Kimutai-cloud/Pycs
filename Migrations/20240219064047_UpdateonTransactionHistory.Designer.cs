﻿// <auto-generated />
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PycsProject.Migrations
{
    [DbContext(typeof(ProjectDbContext))]
    [Migration("20240219064047_UpdateonTransactionHistory")]
    partial class UpdateonTransactionHistory
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PycsProject.AccountManagers", b =>
                {
                    b.Property<int>("AccountManagerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountManagerId"));

                    b.Property<string>("ContactEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountManagerId");

                    b.ToTable("AccountManagers");
                });

            modelBuilder.Entity("PycsProject.AccountTypes", b =>
                {
                    b.Property<int>("AccountTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountTypeId"));

                    b.Property<string>("AccountTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountTypeId");

                    b.ToTable("AccountTypes");
                });

            modelBuilder.Entity("PycsProject.Accounts", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountId"));

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AccountTypesID")
                        .HasColumnType("int");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.HasKey("AccountId");

                    b.HasIndex("AccountTypesID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("PycsProject.Customers", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AccountManagerId")
                        .HasColumnType("int");

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("PycsProject.KYCdetails", b =>
                {
                    b.Property<int>("KycId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KycId"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<string>("KraPin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KycId");

                    b.HasIndex("CustomerID")
                        .IsUnique();

                    b.ToTable("KYCdetails");
                });

            modelBuilder.Entity("PycsProject.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RecipientCustomerId")
                        .HasColumnType("int");

                    b.Property<int>("SenderCustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TransactionId");

                    b.HasIndex("RecipientCustomerId");

                    b.HasIndex("SenderCustomerId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("PycsProject.TransactionHistories", b =>
                {
                    b.Property<int>("TransactionHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionHistoryId"));

                    b.Property<string>("ActionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TransactionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TransactionHistoryId");

                    b.HasIndex("TransactionId")
                        .IsUnique();

                    b.ToTable("TransactionHistories");
                });

            modelBuilder.Entity("PycsProject.Accounts", b =>
                {
                    b.HasOne("PycsProject.AccountTypes", "accountType")
                        .WithMany("Account")
                        .HasForeignKey("AccountTypesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PycsProject.Customers", "customer")
                        .WithMany("accounts")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("accountType");

                    b.Navigation("customer");
                });

            modelBuilder.Entity("PycsProject.Customers", b =>
                {
                    b.HasOne("PycsProject.AccountManagers", "AccountManager")
                        .WithMany("customer")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccountManager");
                });

            modelBuilder.Entity("PycsProject.KYCdetails", b =>
                {
                    b.HasOne("PycsProject.Customers", "customer")
                        .WithOne("KYCdetail")
                        .HasForeignKey("PycsProject.KYCdetails", "CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("customer");
                });

            modelBuilder.Entity("PycsProject.Transaction", b =>
                {
                    b.HasOne("PycsProject.Customers", "RecipientCustomer")
                        .WithMany("ReceivedTransactions")
                        .HasForeignKey("RecipientCustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PycsProject.Customers", "SenderCustomer")
                        .WithMany("SentTransactions")
                        .HasForeignKey("SenderCustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("RecipientCustomer");

                    b.Navigation("SenderCustomer");
                });

            modelBuilder.Entity("PycsProject.TransactionHistories", b =>
                {
                    b.HasOne("PycsProject.Transaction", "transaction")
                        .WithOne("transactionHistory")
                        .HasForeignKey("PycsProject.TransactionHistories", "TransactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("transaction");
                });

            modelBuilder.Entity("PycsProject.AccountManagers", b =>
                {
                    b.Navigation("customer");
                });

            modelBuilder.Entity("PycsProject.AccountTypes", b =>
                {
                    b.Navigation("Account");
                });

            modelBuilder.Entity("PycsProject.Customers", b =>
                {
                    b.Navigation("KYCdetail")
                        .IsRequired();

                    b.Navigation("ReceivedTransactions");

                    b.Navigation("SentTransactions");

                    b.Navigation("accounts");
                });

            modelBuilder.Entity("PycsProject.Transaction", b =>
                {
                    b.Navigation("transactionHistory")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
