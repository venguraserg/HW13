﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace HW13WPF.Model
{
    public class Client : INotifyPropertyChanged
    {
        private Guid id;
        private string name;
        private string surName;
        private string patronymic;
        private string phoneNumber;
        private string passNumber;
        private ICollection<Guid> accountsId;

        public Guid Id
        {
            get => id;
            set
            {
                id = value; 
                OnPropertyChanged("Id");
            }
        }
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
        public ICollection<Guid> AccountsId
        {
            get => accountsId;
            set
            {
                accountsId = value;
                OnPropertyChanged("AccountsId");
            }
        }


        public Client(string name, string surName, string patronymic, string phoneNumber, string passNumber)
        {
            Id = Guid.NewGuid();
            Name = name;
            SurName = surName;
            Patronymic = patronymic;
            PhoneNumber = phoneNumber;
            PassNumber = passNumber;
            AccountsId = new ObservableCollection<Guid>();
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}