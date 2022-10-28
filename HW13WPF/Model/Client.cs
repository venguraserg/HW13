using System;
using System.Collections.Generic;
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


        public Client(string name, string surName)
        {
            Id = Guid.NewGuid();
            Name = name;
            SurName = surName;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
