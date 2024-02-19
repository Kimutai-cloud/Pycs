using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public class Accounts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountId { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }


        public int CustomerID { get; set; }
        public Customers customer { get; set; }

        public int AccountTypesID { get; set; }
        public AccountTypes accountType { get; set; }

    }
    public class AccountTypes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountTypeId { get; set; }
        public string AccountTypeName { get; set; }

        public ICollection<Accounts> Account { get; set; }

    }

}
