using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace labs
{
    class Program
    {
        enum Country
        {
            USA,
            Russian,
            Australia,
            GreatBritain,
        }
        abstract class Human
        {
            public string Name { get; set; }
            public string LastName { get; set; }
            public Human()
            {

            }
            public Human(string name, string lastName)
            {
                Name = name;
                LastName = lastName;
            }
        }
        class Client : Human
        {
            public ulong DatePasport { get; set; } // Номер и серия паспорта
            public Client(string name, string lastname, ulong datePasport) : base(name, lastname)
            {
                DatePasport = datePasport;
            }
            public Client()
            {

            }
        }
        class Seller : Human
        {

            public double Salary { get; set; }
            public byte Experience { get; set; } // Опыт работы в годах поэтому byte
            public int NumOfTicketsSold { get; set; }
            public void RaiseSalary(double sum)
            {
                Salary += sum;
            }
            public Seller(string name, string lastname, double salary, byte experience) : base(name, lastname)
            {
                Salary = salary;
                Experience = experience;
            }
            public Seller(string name, string lastname, double salary)
            {
                Salary = salary;
            }
            public Seller()
            {

            }
        }
        class Ticket
        {
            static public int countTicket = 0;
            private long ID = 3123123;
            public Client Client { get; set; } = new Client();
            public Seller Seller { get; set; } = new Seller();
            public double Price { get; set; }
            public Country CountryEnd { get; set; }

            public Ticket(Client client, Seller seller, Country country)
            {
                Client = client;
                Seller = seller;
                CountryEnd = country;
                Price = GetCost(country);
                seller.NumOfTicketsSold++;
                ID += countTicket;
                countTicket++;
            }
            public void Display()
            {
                Console.WriteLine($"Данные билета #{ID}: ");
                Console.WriteLine($"Клиент: {Client.Name} {Client.LastName} {Client.DatePasport}");
                Console.WriteLine($"Страна: {CountryEnd}");
                Console.WriteLine($"Цена: {Price}");
            }

            private double GetCost(Country country)
            {
                switch (country)
                {
                    case Country.USA:
                        return 150000;
                    case Country.Russian:
                        return 20000;
                    case Country.Australia:
                        return 300000;
                    case Country.GreatBritain:
                        return 350000;
                    default:
                        throw new Exception("Страны не существует!");
                }
            }
        }
        static void Main(string[] args)
        {
            Queue<Client> clients = new Queue<Client>();
            using (StreamReader read = new StreamReader(@"List_clients.txt"))
            {
                string str = read.ReadLine();
                //Читаем построчно пока не дойдем до конца файла
                while ((str = read.ReadLine()) != null)
                {
                    string[] dateClent = str.Split();
                    Client client = new Client(dateClent[0], dateClent[1], Convert.ToUInt64(dateClent[2]));
                    clients.Enqueue(client);
                }
            }
            Seller seller = new Seller();
            Console.WriteLine("Введите имя кассира: ");
            seller.Name = Console.ReadLine(); 
            Console.WriteLine("Введите фамилию кассира: ");
            seller.LastName = Console.ReadLine();
            Console.WriteLine("Введите зарплату кассира: ");
            seller.Salary = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите стаж кассира в годах: ");
            seller.Experience = Convert.ToByte(Console.ReadLine());
            int countCountry = 0;
            while (clients.Count != 0)
            {
                Ticket ticket = new Ticket(clients.Dequeue(), seller, (Country)(countCountry % 4));
                ticket.Display();
                countCountry++;
            }
            Console.WriteLine($"Итого за все время продали: {Ticket.countTicket}");
            if (seller.NumOfTicketsSold > 5)
            {
                Console.WriteLine($"{seller.Name} {seller.LastName} молодец! Он выполнил норму по продажам и получает повышение зарплаты на 100$");
                seller.RaiseSalary(100);
                Console.WriteLine($"Теперь его зарплата: {seller.Salary}");
            }
            if (seller.Experience > 5)
            {
                Console.WriteLine($"Ваш сотрудник {seller.Name} {seller.LastName} старый волк! Он получает повышение зарплаты на 250$");
                seller.RaiseSalary(250);
                Console.WriteLine($"Теперь его зарплата: {seller.Salary}");
            }
            Console.ReadKey();
        }
    }
}