using System;
using System.Collections.Generic;
using System.Text;

namespace HW13WPF.Model
{
    public class Account
    {
        public static int count;
        /// <summary>
        /// Id счета
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Номер счета
        /// </summary>
        public string AccountNumber { get; set; }
        /// <summary>
        /// Валюта
        /// </summary>
        public AccountCurrency Currency { get; set; }
        /// <summary>
        /// Баланс счета
        /// </summary>
        public decimal AccountBalance { get; set; }
        /// <summary>
        /// ID Client
        /// </summary>
        public Guid IdClient { get; set; }


        public Account(AccountCurrency accountCurrency, Guid idClient)
        {
            Id = Guid.NewGuid();
            Currency = accountCurrency;
            AccountBalance = 0;
            IdClient = idClient;

            AccountNumber = accountCurrency.ToString() + "0000" + count.ToString();

            count++;
        }
    }

}
