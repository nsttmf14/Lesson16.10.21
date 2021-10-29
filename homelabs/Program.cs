using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homelabs
{
    class Homework
    {
        private void HeightOfFloor(ref float height, ref byte countFloors) //вычисления высоты, которую занимает каждый этаж
        {
            double Average = height / countFloors;
            Console.WriteLine($"Средняя высота этажа для дома: {Math.Round(Average, 2)}м.");
        }
        private void CountApartmentsInEntrance(ref int countApartments, ref byte countEntrance) //вычисление количества квартир в подъезде
        {
            double Average = countApartments / countEntrance;
            Console.WriteLine($"Среднее количество квартир в каждом подъезде этого дома: {Math.Round(Average, 1)}");
        }
        static void Main(string[] args)
        {
            byte numberOfHome;
            float height;
            byte countFloors;
            int countApartments;
            byte countEntrance;
            Random rnd = new Random();
            List<byte> randomList = new List<byte>();
            Console.Write("Введите количество домов: ");
            byte.TryParse(Console.ReadLine(), out byte count);
            while (count != 0)
            {
            random:
                byte coincidences = (byte)rnd.Next(1, 100); //генерация случайного номера дома
                if (randomList.Contains(coincidences))
                {
                    goto random;
                }
                else
                {
                    randomList.Add(coincidences);//случайный номер без повторений
                    numberOfHome = Convert.ToByte(coincidences);
                    Console.WriteLine("Номер дома (случайный): " + numberOfHome);
                }

                Console.Write("Введите высоту дома (в метрах): "); //высота дома
                float.TryParse(Console.ReadLine(), out height);

                Console.Write("Введите количество этажей в доме: "); //этажи в доме
                string floors = Console.ReadLine();
                if (!byte.TryParse(floors, out countFloors))
                {
                    throw new Exception("Ошибка: введено некорректное значение.");
                }

                Console.Write("Введите количество квартир в доме: "); //квартиры в доме
                string apartments = Console.ReadLine();
                int.TryParse(apartments, out countApartments);

                Console.Write("Введите количество подьездов в доме: "); //подъезды в доме
                string entrances = Console.ReadLine();
                if (!byte.TryParse(entrances, out countEntrance))
                {
                    throw new Exception("Ошибка: введено некоректное значение.");
                }
                var Method = new Homework();
                Method.HeightOfFloor(ref height, ref countFloors);
                Method.CountApartmentsInEntrance(ref countApartments, ref countEntrance);

                count--;
            }

            Console.ReadKey();
        }
        
    }
}

