
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson16._10._21
{
    class BankAccount
    {
        public enum TypeAcc
        {
            currentAccount = 1,
            savingAccount
        }
        public struct Account
        {
            public int number;
            public double balance;
            public TypeAcc type;
        }
        public Dictionary<byte, Account> CreateAndPrintAccounts(Dictionary<byte, Account> Accounts)
        {
            byte accountNumber = 0;
            int coincidences;
            Random rnd = new Random();
            List<int> randomList = new List<int>();
            Console.Write("Введите количество банковских счетов: ");
            byte.TryParse(Console.ReadLine(), out byte accountCount);
            while (accountNumber <= (accountCount + 1))
            {
                Account newUser;

                Console.Write("1. Текущий счёт \n2. Сберегательный счёт \nВыберите счёт: ");
                newUser.type = (TypeAcc)Convert.ToByte(Console.ReadLine());

            random:
                coincidences = rnd.Next(1, 999999);
                if (randomList.Contains(coincidences))
                {
                    goto random;
                }
                else
                {
                    randomList.Add(coincidences);
                    newUser.number = Convert.ToInt32(coincidences);
                }
                Console.WriteLine("номер: " + newUser.number);

                Console.Write("Введите баланс: ");
                string balance = Console.ReadLine();
                double.TryParse(balance, out newUser.balance);

                Accounts.Add(accountNumber, newUser);
                accountNumber++;
                accountCount--;
            }
            foreach (KeyValuePair<byte, Account> keyValue in Accounts) //печать директории аккаунтов
            {
                Console.WriteLine($"Тип {keyValue.Key + 1} счёта : {keyValue.Value.type}\nНомер {keyValue.Key + 1} счёта: {keyValue.Value.number}\nБаланс {keyValue.Key + 1} счёта: {keyValue.Value.balance}");
            }
            return Accounts;
        }
        class program : BankAccount
        {

            static void Main(string[] args)
            {

                Dictionary<byte, Account> Accounts = new Dictionary<byte, Account>();
                var obj = new BankAccount();
                obj.CreateAndPrintAccounts(Accounts);

            }
        }
    }
}


