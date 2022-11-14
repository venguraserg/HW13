using System;
using System.Collections.Generic;
using System.Text;

namespace HW13WPF.Model.Accounts
{
    public class IndividualAccount : Account
    {
        public IndividualAccount(AccountCurrency accountCurrency, Guid idClient) : base(accountCurrency, idClient)
        {
        }
    }
}
