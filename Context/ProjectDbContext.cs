using Microsoft.EntityFrameworkCore;
using DataAccess.Models;
using DataAccess.Generators;

namespace DataAccess.Context
{
    public class ProjectDbContext : DbContext
    {
        public DbSet<Customers> Customers { get; set; }
        public DbSet<AccountManagers> AccountManagers { get; set; }
        public DbSet<KYCdetails> KYCdetails { get; set; }
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<AccountTypes> AccountTypes { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionHistories> TransactionHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .Build();

                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customers>()
                .Property(c => c.CustomerID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Customers>()
                .HasOne(c => c.KYCdetail)
                .WithOne(k => k.customer)
                .HasForeignKey<KYCdetails>(k => k.CustomerID);

            modelBuilder.Entity<Customers>()
                .HasOne(c => c.AccountManager)
                .WithMany(a => a.customer)
                .HasForeignKey(a => a.CustomerID);

            modelBuilder.Entity<Accounts>()
                .HasOne(a => a.customer)
                .WithMany(c => c.accounts)
                .HasForeignKey(a => a.CustomerID);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.RecipientCustomer)
                .WithMany(c => c.ReceivedTransactions)
                .HasForeignKey(t => t.RecipientCustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.SenderCustomer)
                .WithMany(c => c.SentTransactions)
                .HasForeignKey(t => t.SenderCustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Accounts>()
                .HasOne(a => a.accountType)
                .WithMany(at => at.Account)
                .HasForeignKey(a => a.AccountTypesID);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.transactionHistory)
                .WithOne(th => th.transaction)
                .HasForeignKey<TransactionHistories>(th => th.TransactionId);
        }

        public override int SaveChanges()
        {
            var transactionHistoriesToAdd = TransactionHistoryGenerator.GenerateTransactionHistories(this);
            TransactionHistories.AddRange(transactionHistoriesToAdd);
            return base.SaveChanges();
        }

    }
}



