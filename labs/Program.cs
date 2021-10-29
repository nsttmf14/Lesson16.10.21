
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson16._10._21
{

    class program
    {
        private enum TypeAcc
        {
            currentAccount = 1,
            savingAccount
        }

        private static int number;
        private static double balance;
        private static TypeAcc type;
        static string Create()//создаем счет
        {
            Random rnd = new Random();
            int coincidences;
            List<int> randomList = new List<int>();
            Console.Write("1. Текущий счёт (current account)\n2. Сберегательный счёт (saving account) \nВыберите тип счёта: ");
            type = (TypeAcc)Convert.ToByte(Console.ReadLine());
        random:
            coincidences = rnd.Next(1, 999999);
            if (randomList.Contains(coincidences))//проверяем, чтобы рандомный номер не совпадал
            {
                goto random;
            }
            else
            {
                randomList.Add(coincidences);
                number = Convert.ToInt32(coincidences);
            }
            Console.WriteLine("Номер сгенерирован случайно, без повторений.");
            Console.Write("Введите баланс: ");
            string input = Console.ReadLine();
            double.TryParse(input, out balance);
            string account = type + " " + number + " " + balance;
            return account;
        }
        static void Print(string account)//печатаем счет
        {
            string[] acc = account.Split();
            Console.WriteLine($"\n1.Тип счёта: {acc[0]}\n2.Номер счёта {acc[1]}\n3.Баланс счёта: {acc[2]}");
        }
        static string Transaction(string account)//для транзакций
        {
            string[] acc = account.Split();
            Console.WriteLine("1.Снять наличные\n2Пополнить счёт");
        transaction:
            if (!byte.TryParse(Console.ReadLine(), out byte choise) | choise > 2)
            {
                Console.WriteLine("Ошибка: введено некорректное значение. Повторите ввод:");
                goto transaction;
            }
            Console.Write("Введите сумму транзакции: ");
            double.TryParse(Console.ReadLine(), out double transfer);
            double Buffer = Convert.ToDouble(acc[2]);
            if (choise.Equals(1))
            {
                Console.WriteLine("Спасибо, наличные сняты");
                Buffer -= transfer;
            }
            else
            {
                Console.WriteLine("Спасибо, деньги зачислены");
                Buffer += transfer;
            }
            acc[2] = Convert.ToString(Buffer);
            Console.WriteLine("Текущий баланс счёта: " + acc[2]);
            return account = acc[0] + " " + acc[1] + " " + acc[2]; //сохранение нового баланса счёта
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Task 8.1");
            Console.WriteLine("Создание счёта.");
            string account = Create();
        start:
            Console.WriteLine("* * * Меню * * *");
            Console.WriteLine("1.Напечатать информацию о счёте");
            Console.WriteLine("2.Транзакция");
            Console.Write("Выберите. ");
        restart:
            if (!byte.TryParse(Console.ReadLine(), out byte choice) | choice > 2)
            {
                Console.WriteLine("Ошибка: введено некорректное значение. Повторите ввод: ");
                goto restart;
            }
            else
            {
                switch (choice)
                {
                    case 1:
                        {
                            Print(account); goto start; //печать данных о счёте
                        }
                    case 2:
                        {
                            account = Transaction(account); //транзакция
                            break;
                        }
                }
            }
        }
    }
}



