using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DataAccess.Generators
{

    public static class Seeder
    {
        /*public static List<AccountManagers> GenerateAccountManager(int count)
        {
            var managers = new List<AccountManagers>();
            for (int i = 1; i <= count; i++)
            {
                var manager = new AccountManagers()
                {
                    FirstName = $"FirstName {i}",
                    LastName = $"LastName {i}",
                    ContactEmail = $"customer{i}@example.com",
                    ContactPhone = $"123-456-{i:0000}"
                };
                managers.Add(manager);
            }
            return managers;
        }*/
        /*public static List<Customers> GenerateCustomers(int count, ProjectDbContext context)
        {
            var random = new Random();
            var managers = context.AccountManagers.ToList();
            var customers = new List<Customers>();
            for (int i = 1 ; i <= count; i++)
            {
                var customer = customers[random.Next(customers.Count)];
                var customeR = new Customers()
                {
                    CustomerName = $"Customer {i}",
                    CustomerEmail = $"customer{i}@example.com",
                    CustomerPhone = $"123-456-{i:0000}",
                    AccountManagerId = manager.AccountManagerId
                };
                customers.Add(customeR);
            }
            return customers;
        }*/

        /*public static List<AccountTypes> GenerateAccountTypes()
        {
            var accountTypes = new List<AccountTypes>
            {
                new AccountTypes { AccountTypeName = "Savings" },
                new AccountTypes { AccountTypeName = "Checking" },
                new AccountTypes { AccountTypeName = "Investment" },
                new AccountTypes { AccountTypeName = "Loan" },
                new AccountTypes { AccountTypeName = "Credit Card" }
            };
            return accountTypes;
        }*/

        /*public static List<Accounts> GenerateAccounts(int count, ProjectDbContext context)
        {
            var accounts = new List<Accounts>();
            var random = new Random();
            var customers = context.Customers.ToList();
            var accountTypes = context.AccountTypes.ToList();
            for (int i = 1; i <= count; i++)
            {
                var accountType = accountTypes[random.Next(accountTypes.Count)];
                var customer = customers[random.Next(customers.Count)];

                var account = new Accounts
                {
                    
                    AccountNumber = $"ACC{i:0000}",
                    Balance = 1000 * i,
                    CustomerID = i % 10 + 1,
                    AccountTypesID = accountType.AccountTypeId
                };
                accounts.Add(account);
            }
            return accounts;
        }*/



        /*public static List<Transaction> GenerateTransactions( ProjectDbContext context)
        {
            var transactions = new List<Transaction>();
            var random = new Random();
            var customers = context.Customers.ToList();
                var senderIndex = customers[random.Next(customers.Count)];
                var recipientIndex = customers[random.Next(customers.Count)];
                while (senderIndex == recipientIndex)
                {
                    recipientIndex = customers[random.Next(customers.Count)];
                }
                var transaction = new Transaction
                {
                    SenderCustomerId = senderIndex.CustomerID,
                    RecipientCustomerId = recipientIndex.CustomerID,
                    Amount = random.Next(100, 1000),

                };
                transactions.Add(transaction);
            return transactions;
        }*/
        /*public static List<KYCdetails> GenerateKYCDetails(int count, ProjectDbContext context)
        {
            var KYCDetails = new List<KYCdetails>();
            var random = new Random();
            var customers = context.Customers.ToList();
            for (int i = 1; i <= count; i++)
            {
                var customer = customers[random.Next(customers.Count)];

                var kycdetail = new KYCdetails
                {

                    CompanyName = $"Company {i}",
                    KraPin = $"KRA{i:0000}",
                    CustomerID = customer.CustomerID
                };
                KYCDetails.Add(kycdetail);
            }
            return KYCDetails;
        }*/
    }
}
