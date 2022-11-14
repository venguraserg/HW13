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
    public class BussinesClient : Client
    {
           
        private string nameCompany;
        private string nameSupervisor;
        private string registrationNumber;
       
        public string NameCompany
        {
            get => nameCompany;
            set
            {
                nameCompany = value;
                OnPropertyChanged("NameCompany");
            }
        }
        public string NameSupervisor
        {
            get => nameSupervisor;
            set
            {
                nameSupervisor = value;
                OnPropertyChanged("NameSupervisor");
            }
        }
        public string RegistrationNumber
        {
            get => registrationNumber;
            set
            {
                registrationNumber = value;
                OnPropertyChanged("RegistrationNumber");
            }
        }


        public BussinesClient(string nameCompany, string nameSupervisor, string registrationNumber) : base()
        {
            Id = Guid.NewGuid();            
            NameCompany = nameCompany;
            NameSupervisor = nameSupervisor;
            RegistrationNumber = registrationNumber;
            Accounts = new ObservableCollection<Account>();
        }

        //public event PropertyChangedEventHandler PropertyChanged;
        //public void OnPropertyChanged([CallerMemberName] string prop = "")
       // {
       //     PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
       // }

       // public void NewMethod()
       // {
      //      throw new NotImplementedException();
       // }
    }
}
