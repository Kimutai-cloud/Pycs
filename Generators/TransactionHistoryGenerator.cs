using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Generators
{
    public static class TransactionHistoryGenerator
    {
        public static List<TransactionHistories> GenerateTransactionHistories(DbContext context)
        {
            var entries = context.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted);

            var transactionHistoriesToAdd = new List<TransactionHistories>();

            foreach (var entry in entries)
            {
                if (entry.Entity is Transaction transaction && entry.State == EntityState.Added)
                {
                    string actionType;
                    if (entry.State == EntityState.Added)
                    {
                        actionType = "Added";
                    }
                    else if (entry.State == EntityState.Modified)
                    {
                        actionType = "Updated";
                    }
                    else
                    {
                        actionType = "Deleted";
                    }
                    var transactionId = transaction.TransactionId;

                    var transactionHistory = new TransactionHistories
                    {
                        TransactionId = transaction.TransactionId,
                        ActionType = actionType,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now
                    };

                    transactionHistoriesToAdd.Add(transactionHistory);
                }
            }
            return transactionHistoriesToAdd;
        }
    }
}
