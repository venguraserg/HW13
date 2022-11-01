using HW13WPF.Command;
using HW13WPF.Model;
using HW13WPF.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
        
        private ObservableCollection<Client> clients;                   //Поле коллекции клиентов
        private ObservableCollection<Account> accounts;                 //Поле коллекции счетов
        private Client selectedClient;                                  //Поле выделенного клиента
        private ObservableCollection<Account> selectedClientAccounts;   //Поле счетов выделенного клинта
        private Account selectedAccount;                                //Поле выделенного счета

        

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
        public Account SelectedAccount
        {
            get => selectedAccount;
            set
            {
                selectedAccount = value;
                OnPropertyChanged("SelectedAccount");
            }
        }
        #endregion

        #region Поля и свойства нового клиента
        private string newClientName;
        private string newClientSurName;
        private string newClientPatronymic;
        private string newClientPhoneNumber;
        private string newClientPassNumber;

        public string NewClientName
        {
            get => newClientName;
            set
            {
                newClientName = value;
                OnPropertyChanged("NewClientName");
            }
        }
        public string NewClientSurName
        {
            get => newClientSurName;
            set
            {
                newClientSurName = value;
                OnPropertyChanged("NewClientSurName");
            }
        }
        public string NewClientPatronymic
        {
            get => newClientPatronymic;
            set
            {
                newClientPatronymic = value;
                OnPropertyChanged("NewClientPatronymic");
            }
        }
        public string NewClientPhoneNumber
        {
            get => newClientPhoneNumber;
            set
            {
                newClientPhoneNumber = value;
                OnPropertyChanged("NewClientPhoneNumber");
            }
        }
        public string NewClientPassNumber
        {
            get => newClientPassNumber;
            set
            {
                newClientPassNumber = value;
                OnPropertyChanged("NewClientPassNumber");
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
            if(MessageBox.Show("Удалить клиента","Удалить?",MessageBoxButton.YesNo,MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                var removedAccount = Accounts.Where(i => i.IdClient == selectedClient.Id).ToList();
                for (int i = 0; i < removedAccount.Count; i++)
                {
                    Accounts.Remove(removedAccount[i]);
                }

                Clients.Remove(SelectedClient);

                LoadSaveData.Save(CLIENT_FILE_NAME, Clients);
                LoadSaveData.Save(ACCOUNT_FILE_NAME, Accounts);
            }
            
        }
        private bool CanDeleteSelectedClientCommandExecute(object p) => SelectedClient is Client;
                
        /// <summary>
        /// Команда изменеия клиента
        /// </summary>
        public ICommand UpdateSelectClientCommand { get; }
        private void OnUpdateSelectClientCommandExecuted(object p)
        {
            LoadSaveData.Save(CLIENT_FILE_NAME, Clients);
            LoadSaveData.Save(ACCOUNT_FILE_NAME, Accounts);
        }
        private bool CanUpdateSelectClientCommandExecute(object p) => true;
        
        /// <summary>
        /// Команда изменеия клиента
        /// </summary>
        public ICommand AddClientCommand { get; }
        private void OnAddClientCommandExecuted(object p)
        {
            var client = new Client(NewClientName, NewClientSurName, NewClientPatronymic, NewClientPhoneNumber, NewClientPassNumber);
            Clients.Insert(0, client);
            LoadSaveData.Save(CLIENT_FILE_NAME, Clients);
        }
        private bool CanAddClientCommandExecute(object p) => !(NewClientName==null || 
                                                              NewClientSurName == null ||
                                                              NewClientPatronymic == null ||
                                                              NewClientPhoneNumber == null ||
                                                              NewClientPassNumber == null);

        /// <summary>
        /// Команда открытия счета клиента
        /// </summary>
        public ICommand AddAccountCommand { get; }
        private void OnAddAccountCommandExecuted(object p)
        {
            var newAccount = new Account(AccountCurrency.BYN, SelectedClient.Id);
            Accounts.Add(newAccount);
            SelectedClient.AccountsId.Add(newAccount.Id);
        }
        private bool CanAddAccountCommandExecute(object p) => true;




        #endregion

        public MainWindowViewModel()
        {
            #region Команды
            CloseAppCommand = new LambdaCommand(OnCloseAppCommandExecuted, CanCloseAppCommandExecute);
            DeleteSelectedClientCommand = new LambdaCommand(OnDeleteSelectedClientCommandExecuted, CanDeleteSelectedClientCommandExecute);
            UpdateSelectClientCommand = new LambdaCommand(OnUpdateSelectClientCommandExecuted, CanUpdateSelectClientCommandExecute);
            AddClientCommand = new LambdaCommand(OnAddClientCommandExecuted, CanAddClientCommandExecute);
            AddAccountCommand = new LambdaCommand(OnAddAccountCommandExecuted, CanAddAccountCommandExecute);
            #endregion

            //Инициализация свойств
            Clients = new ObservableCollection<Client>();
            Accounts = new ObservableCollection<Account>();
            SelectedClientAccounts = new ObservableCollection<Account>();

            //Загрузка списка клиентов из файла
            Clients = LoadSaveData.Load<Client>(CLIENT_FILE_NAME);

            //Если записей нет, для теста автозаполнение
            if (Clients.Count == 0)
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
