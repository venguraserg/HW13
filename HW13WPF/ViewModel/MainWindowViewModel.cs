using HW13WPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace HW13WPF.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Client> clients;
        public ObservableCollection<Client> Clients
        {
            get => clients;
            set
            {
                clients = value;
                OnPropertyChanged("Clients");
            }
        }


        public MainWindowViewModel()
        {
            Clients = new ObservableCollection<Client>();

            for(int i = 0; i < 100; i++)
            {
                Clients.Add(new Client("Name" + i.ToString(), "Surname" + i.ToString()));
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
