using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW13_WPF.Model
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public string PassNumber { get; set; }
        public List<Account> Accounts { get; set; }
        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Client() { }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id"></param>
        /// <param name="surname"></param>
        /// <param name="name"></param>
        /// <param name="patronymic"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="passNumber"></param>
        /// <param name="change"></param>
        public Client(Guid id, string surname, string name, string patronymic, string phoneNumber, string passNumber)
        {
            Id = id;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            PhoneNumber = phoneNumber;
            PassNumber = passNumber;
        }
    }
}
