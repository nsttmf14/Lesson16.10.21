using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homelabs
{
    class House
    {
        public struct Home
        {
            public byte numberOfHome;
            public float height;
            public byte countFloors;
            public int countApartments;
            public byte countEntrance;
        }
        public void HeightOfFloor(Dictionary<byte, Home> Houses) //вычисления высоты, которую занимает каждый этаж
        {
            foreach (KeyValuePair<byte, Home> keyValue in Houses)
            {
                Console.WriteLine($"Номер дома: {keyValue.Value.numberOfHome}\nВысота дома: {keyValue.Value.height}\nКоличество этажей в доме: {keyValue.Value.countFloors}\nКоличество квартир в доме: {keyValue.Value.countApartments}" +
                $"\nКоличество подъездов в доме: {keyValue.Value.countEntrance}");
                double average = keyValue.Value.height / keyValue.Value.countFloors;
                Console.WriteLine($"Средняя высота, которую занимает один этаж в этом доме: {Math.Round(average, 2)}м.");
            }
        }
        public void CountApartmentsInEntrance(Dictionary<byte, Home> Houses) //вычисление количества квартир в подъезде
        {
            foreach (KeyValuePair<byte, Home> keyValue in Houses)
            {
                Console.WriteLine($"Номер дома: {keyValue.Value.numberOfHome}\nВысота дома: {keyValue.Value.height}\nКоличество этажей в доме: {keyValue.Value.countFloors}\nКоличество квартир в доме: {keyValue.Value.countApartments}" +
                $"\nКоличество подъездов в доме: {keyValue.Value.countEntrance}");
                double countApartments = keyValue.Value.countApartments / keyValue.Value.countEntrance;
                Console.WriteLine($"Среднее количество квартир в каждом подъезде этого дома: {Math.Round(countApartments, 1)}");
            }
        }
    }
    class Homework : House
    {
        static void Main(string[] args)
        {
            Dictionary<byte, Home> Houses = new Dictionary<byte, Home>();
            Random rnd = new Random();
            List<byte> randomList = new List<byte>();
            Console.Write("Введите количество зданий: ");
            byte.TryParse(Console.ReadLine(), out byte countHomes);
            byte numberHome = 0;
            while (countHomes != 0)
            {
                Home newHome;

            random:
                byte coincidences = (byte)rnd.Next(1, 100); //генерация случайного номера дома
                if (randomList.Contains(coincidences))
                {
                    goto random;
                }
                else
                {
                    randomList.Add(coincidences); //нужно для того, если вдруг рандомное число повторится
                    newHome.numberOfHome = Convert.ToByte(coincidences);
                }
                Console.WriteLine("Номер дома: " + newHome.numberOfHome);

                Console.Write("Введите высоту дома (в метрах): "); //высота дома
                string height = Console.ReadLine();
                float.TryParse(height, out newHome.height);

                Console.Write("Введите количество этажей в доме: "); //этажи в доме
                string floors = Console.ReadLine();
                byte.TryParse(floors, out newHome.countFloors);//проверяет, чтобы были введены только числа

                Console.Write("Введите количество квартир в доме: "); //квартиры в доме
                string apartments = Console.ReadLine();
                int.TryParse(apartments, out newHome.countApartments);

                Console.Write("Введите количество подъездов в доме: "); //подъезды в доме
                string entrances = Console.ReadLine();
                byte.TryParse(entrances, out newHome.countEntrance);
                Houses.Add(newHome.numberOfHome, newHome);
                numberHome++;
                countHomes--;
            }

            var obj = new House();
            obj.HeightOfFloor(Houses);
            obj.CountApartmentsInEntrance(Houses);

            Console.ReadKey();
        }
    }

}
