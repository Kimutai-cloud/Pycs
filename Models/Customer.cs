using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public class Customers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }

        public KYCdetails KYCdetail { get; set; }

        public int AccountManagerId { get; set; }
        public AccountManagers AccountManager { get; set; }

        public ICollection<Accounts> accounts { get; set; }
        public ICollection<Transaction> SentTransactions { get; set; }

        public ICollection<Transaction> ReceivedTransactions { get; set; }

    }

    public class KYCdetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KycId { get; set; }
        public string CompanyName { get; set; }
        public string KraPin { get; set; }

        public int CustomerID { get; set; }
        public Customers customer { get; set; }

    }
    public class AccountManagers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountManagerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }

        public ICollection<Customers> customer { get; set; }
    }
}
