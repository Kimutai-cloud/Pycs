using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionId { get; set; }

        [ForeignKey("CustomerID")]
        public int SenderCustomerId { get; set; }

        public Customers SenderCustomer { get; set; }

        [ForeignKey("CustomerID")]
        public int RecipientCustomerId { get; set; }
        public Customers RecipientCustomer { get; set; }
        public decimal Amount { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public TransactionHistories transactionHistory { get; set; }
    }

    public class TransactionHistories
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionHistoryId { get; set; }
        public string ActionType { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public int TransactionId { get; set; }
        [ForeignKey("TransactionId")]
        public Transaction transaction { get; set; }
    }


}
