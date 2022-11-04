using System;
using System.Collections.Generic;
using System.Text;

namespace HW13WPF.Model
{
    public class VIP_Account : Account
    {
        public VIP_Account(AccountCurrency accountCurrency, Guid idClient) : base(accountCurrency, idClient)
        {
        }
    }

}
