using HW13WPF.Interfaces;
using HW13WPF.Model.Accounts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace HW13WPF.Model.Clients
{
    public class IndividualClient : Client
    {
        
        private string name;
        private string surName;
        private string patronymic;
        private string phoneNumber;
        private string passNumber;
        private ObservableCollection<Account> accounts;
        

        

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public string SurName
        {
            get => surName;
            set
            {
                surName = value;
                OnPropertyChanged("SurName");
            }
        }
        public string Patronymic
        {
            get => patronymic;
            set
            {
                patronymic = value;
                OnPropertyChanged("Patronymic");
            }
        }
        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                phoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }
        public string PassNumber
        {
            get => passNumber;
            set
            {
                passNumber = value;
                OnPropertyChanged("PassNumber");
            }
        }

        
        public IndividualClient(string name, string surName, string patronymic, string phoneNumber, string passNumber):base()
        {
            Id = Guid.NewGuid();
            Name = name;
            SurName = surName;
            Patronymic = patronymic;    
            PhoneNumber = phoneNumber;
            PassNumber = passNumber;
            Accounts = new ObservableCollection<Account>();

        }



       /* public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public void NewMethod()
        {
            throw new NotImplementedException();
        }*/
    }
}
