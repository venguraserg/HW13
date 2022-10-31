using HW13WPF.Model;
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
        public static ObservableCollection<Client> ClientAutofill(int number , string FILE_NAME)
        {
            var Clients = new ObservableCollection<Client>();
            for (int i = 0; i < number; i++)
            {
                string tempGuid = Guid.NewGuid().ToString();
                string[] stringMassive = tempGuid.Split(new char[] { '-' });

                Clients.Add(new Client(stringMassive[0], stringMassive[1], stringMassive[2], stringMassive[3], stringMassive[4])); ;
            }
            Save(FILE_NAME, Clients);
            return Clients;
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
