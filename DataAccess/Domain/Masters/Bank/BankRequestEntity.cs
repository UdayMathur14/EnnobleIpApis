
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Domain.Masters.Bank
{
    public class BankRequestEntity
    {
        public decimal Id { get; set; }

        public string? Status { get; set; }
    }
}
