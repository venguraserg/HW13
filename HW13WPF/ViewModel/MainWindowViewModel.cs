using HW13WPF.Command;
using HW13WPF.Model;
using HW13WPF.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace HW13WPF.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {   
        /// <summary>
        /// Поля имени фалов данных
        /// </summary>
        private const string CLIENT_FILE_NAME = "client_data.json";
        private const string ACCOUNT_FILE_NAME = "acount_data.json";

        #region Поля и свойства

        private ObservableCollection<Client> clients;
        private ObservableCollection<Account> accounts;
        private Client selectedClient;
        private ObservableCollection<Account> selectedClientAccounts;
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
                SelectedClientAccounts.Clear();
                if (SelectedClient != null)
                {
                    foreach (Account item in Accounts)
                    {
                        if (item.IdClient == selectedClient.Id)
                        {
                            SelectedClientAccounts.Add(item);
                        }
                    }
                }
                           
                OnPropertyChanged("SelectedClient");
            }
        }
        public ObservableCollection<Account> Accounts
        {
            get => accounts;
            set
            {
                accounts = value;
                OnPropertyChanged("Accounts");
            }
        }
        public ObservableCollection<Account> SelectedClientAccounts
        {
            get => selectedClientAccounts;
            set
            {
                selectedClientAccounts = value;
                OnPropertyChanged("SelectedClientAccount");
            }
        }
        #endregion


        #region Команды
        /// <summary>
        /// Команда закрыть приложение
        /// </summary>
        public ICommand CloseAppCommand { get; }
        private void OnCloseAppCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }
        private bool CanCloseAppCommandExecute(object p) => true;


        /// <summary>
        /// Команда Удаления клиента
        /// </summary>
        public ICommand DeleteSelectedClientCommand { get; }
        private void OnDeleteSelectedClientCommandExecuted(object p)
        {
            //Доработать удаление из списка счетов.
            //Accounts.
            Clients.Remove(SelectedClient);
        }
        private bool CanDeleteSelectedClientCommandExecute(object p) => SelectedClient is Client;
        #endregion

        public MainWindowViewModel()
        {
            #region Команды
            CloseAppCommand = new LambdaCommand(OnCloseAppCommandExecuted, CanCloseAppCommandExecute);
            DeleteSelectedClientCommand = new LambdaCommand(OnDeleteSelectedClientCommandExecuted, CanDeleteSelectedClientCommandExecute);
            #endregion

            //Инициализация свойств
            Clients = new ObservableCollection<Client>();
            Accounts = new ObservableCollection<Account>();
            SelectedClientAccounts = new ObservableCollection<Account>();

            //Загрузка списка клиентов из файла
            Clients = LoadSaveData.Load<Client>(CLIENT_FILE_NAME);

            //Если записей нет, для теста автозаполнение
            if(Clients.Count == 0)
            {
                if (MessageBox.Show("Список клиентов пуст\nЗаполнить Автоматически?", "Информация", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    LoadSaveData.ClientAutofill(100);
                    Clients = LoadSaveData.Load<Client>(CLIENT_FILE_NAME);

                    if (MessageBox.Show("Список счетов пуст\nЗаполнить Автоматически?", "Информация", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        Clients = LoadSaveData.AccountAutofill(Clients);
                        LoadSaveData.Save(CLIENT_FILE_NAME, Clients);
                        
                    }

                }
            }
            ///Загрузка списка счетов из файла
            Accounts = LoadSaveData.Load<Account>(ACCOUNT_FILE_NAME);









        }





        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
