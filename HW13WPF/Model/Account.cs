using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace HW13WPF.Model
{
    public class Account : INotifyPropertyChanged
    {
        public static int count;
        private Guid id;
        private string accountNumber;
        private AccountCurrency currency;
        private decimal accountBalance;
        private Guid idClient;



        /// <summary>
        /// Id счета
        /// </summary>
        public Guid Id 
        { 
            get => id; 
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }  
        }
        /// <summary>
        /// Номер счета
        /// </summary>
        public string AccountNumber 
        { 
            get => accountNumber; 
            set
            {
                accountNumber = value;
                OnPropertyChanged("AccountNumber");
            }
             
        }
        /// <summary>
        /// Валюта
        /// </summary>
        public AccountCurrency Currency 
        { 
            get => currency; 
            set
            {
                currency = value;
                OnPropertyChanged("AccountNumber");
            }
            
        }
        /// <summary>
        /// Баланс счета
        /// </summary>
        public decimal AccountBalance 
        {
            get => accountBalance;
            set
            {
                accountBalance = value;
                OnPropertyChanged("AccountBalance");
            }
        }
        /// <summary>
        /// ID Client
        /// </summary>
        public Guid IdClient 
        { 
            get => idClient;
            set 
            { 
                idClient = value;
                OnPropertyChanged("IdClient");
            } 
        }


        public Account(AccountCurrency accountCurrency, Guid idClient)
        {
            Id = Guid.NewGuid();
            Currency = accountCurrency;
            AccountBalance = 0;
            IdClient = idClient;

            AccountNumber = accountCurrency.ToString() + "0000" + count.ToString();

            count++;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

}
