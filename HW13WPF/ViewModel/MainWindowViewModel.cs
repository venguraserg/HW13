using HW13WPF.Model;
using HW13WPF.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;

namespace HW13WPF.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private const string FILE_NAME = "data.json";

        private ObservableCollection<Client> clients;
        private ObservableCollection<Account> accounts;
        private Client selectedClient;
        public ObservableCollection<Client> Clients
        {
            get => clients;
            set
            {
                clients = value;
                OnPropertyChanged("Clients");
            }
        }
        public Client SelectedClient
        {
            get => selectedClient;
            set
            {
                selectedClient = value;
                OnPropertyChanged("SelectedClient");
            }
        }



        public MainWindowViewModel()
        {
            Clients = new ObservableCollection<Client>();

            Clients = LoadSaveData.Load<Client>(FILE_NAME);
            if(Clients.Count == 0)
            {
                if(MessageBox.Show("Список клиентов пуст\nЗаполнить Автоматически?", "Информация", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    Clients = LoadSaveData.ClientAutofill(100, FILE_NAME);
                }
            }
        }





        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
