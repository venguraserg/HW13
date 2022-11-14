using HW13WPF.Interfaces;
using HW13WPF.Model.Accounts;
using HW13WPF.Model.Clients;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace HW13WPF.Services
{
    public static class LoadSaveData
    {
        
        /// <summary>
        /// Автозаполнение клиентов для теста
        /// </summary>
        /// <param name="number"></param>
        public static void ClientAutofill(int number)
        {
            var clients = new ObservableCollection<Client>();
            var rnd = new Random();

            for (int i = 0; i < number; i++)
            {
                string tempGuid = Guid.NewGuid().ToString();
                string[] stringMassive = tempGuid.Split(new char[] { '-' });
                Client newClient;
                if (i % 2 == 1)
                {
                    newClient = new IndividualClient("Name" + stringMassive[0].ToString(),
                                          "Surname" + stringMassive[1].ToString(),
                                          "Pat" + stringMassive[2].ToString(),
                                          "Ph#" + stringMassive[3].ToString(),
                                          "N_pass" + stringMassive[4].ToString());
                }
                else
                {
                    newClient = new BussinesClient("Company " + stringMassive[0].ToString(),
                                                   "Supervisor " + stringMassive[1].ToString(),
                                                   "Reg#" + stringMassive[2].ToString());
                }

                



                for (int j = 0; j < rnd.Next(1, 5); j++)
                {
                    Account newAccount;
                    if (j % 2 == 1)
                    {
                        newAccount = new IndividualAccount((AccountCurrency)j, newClient.Id);
                    }
                    else
                    {
                        newAccount = new VIP_Account((AccountCurrency)j, newClient.Id);
                    }
                        
                    newClient.Accounts.Add(newAccount);
                    
                }
                

                clients.Add(newClient);
            }
            Save("client_data.json", clients);           

        }
        

        /// <summary>
        /// Десериализация данных их файла
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static ObservableCollection<T> Load<T>(string fileName)
        {
            ObservableCollection<T> tempItems = new ObservableCollection<T>();

            if (File.Exists(fileName) == false)
            {
                using (File.Create(fileName)) { };
                ObservableCollection<T> tempItemList = new ObservableCollection<T>();
                return tempItemList;
            }
            else
            {
                string json = File.ReadAllText(fileName);
                if (string.IsNullOrEmpty(json)) return new ObservableCollection<T>();
                var items = JsonConvert.DeserializeObject<ObservableCollection<T>>(json);
                return items;
            }
        }

        /// <summary>
        /// Сериализация данных их файла
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <param name="items"></param>
        public static void Save<T>(string fileName, ObservableCollection<T> items)
        {
            if (File.Exists(fileName) == false)
            {
                using (File.Create(fileName)) { };
            }

            string json = JsonConvert.SerializeObject(items);
            File.WriteAllText(fileName, json);
        }
    }
}
