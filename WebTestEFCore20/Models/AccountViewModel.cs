using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTestEFCore20.Models
{
    public class AccountViewModel
    {
        readonly Account _account;

        public AccountViewModel(Account account)
        {
            _account = account;
        }

        public long Number => _account.Number;
        public decimal Saldo => _account.Saldo;
        public string OwnerType => _account.Owner.OwnerType;
        public string OwnerName => _account.Owner.OwnerName;
    }
}
