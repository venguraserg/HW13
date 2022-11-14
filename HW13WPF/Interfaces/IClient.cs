using HW13WPF.Model.Accounts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace HW13WPF.Interfaces
{
    public interface IClient : INotifyPropertyChanged
    {
        public Guid Id { get; }
        public ObservableCollection<Account> Accounts { get; set; }
        public void NewMethod();
    }
}
