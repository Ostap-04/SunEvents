namespace SunEvents
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; //Українська мова в консолі
            int sleepTime = 1000; //Для імітації плину часу

            // Для стеження за днями тижня, зокрема для класу girl
            Dictionary<int, string> week = new Dictionary<int, string>() 
            {
                {1, "Понеділок"}, {2, "Вівторок" }, {3, "Середа" }, {4, "Четвер" },
                {5, "П'ятниця" }, {6, "Субота" }, {7, "Неділя" },
            };

            // Створення екземплярів
            Sun mySun = new Sun();
            Flower mak = new Flower("Мак", "денна", 10);
            Flower romashka = new Flower("Ромашка", "денна", 17);
            Flower matiolla = new Flower("Матіола", "вечірня", 23);
            Bee bee= new Bee();
            NightButterfly butterfly= new NightButterfly();
            Girl girl= new Girl("Марічка");
            // для полегшення реєстрації на події і відписки від поодій
            Flower[] flowers = new Flower[] { mak, romashka, matiolla };

            // підписання на події
            mySun.SunRise += bee.BeeHandleSunRise;
            mySun.SunRise += butterfly.NightButterflyHandleSunRise;
            mySun.SunSet += bee.BeeHandleSunSet;
            mySun.SunSet += butterfly.NightButterflyHandleSunSet;
            foreach (Flower f in flowers)
            {
                if (f.FloweringPeriod != 0)
                {
                    mySun.Morning += f.FlowerHandleMorning;
                    mySun.Afternoon += f.FlowerHandleAfternoon;
                }
            }
            mak.Open += bee.BeeHandleOpenFlowers;
            romashka.Open += bee.BeeHandleOpenFlowers;
            matiolla.Open += bee.BeeHandleOpenFlowers;
            matiolla.Open += butterfly.ButterflyHandleOpenFlowers;

            // імітація днів в цьому випадку для 30 днів
            int day = 1;
            for (int i = 1; i <= 30; i++)
            {
                Console.WriteLine(week[day]); // для вивиедення днів тижня на консоль
                if (week[day] == "Субота" || week[day] == "Неділя") // перевіряємо дні тижня для girl
                {   // оскільки вихідні, girl підписується на денні квіти
                    // в разі більшої кількосі квітів зручніше користуватися масивом для підписки/відписки
                    matiolla.Open -= girl.GirlHandleFlowers;
                    mak.Open -= girl.GirlHandleFlowers;
                    romashka.Open -= girl.GirlHandleFlowers;

                    mak.Open += girl.GirlHandleFlowers;
                    romashka.Open += girl.GirlHandleFlowers;
                }
                else
                {
                    matiolla.Open -= girl.GirlHandleFlowers;
                    mak.Open -= girl.GirlHandleFlowers;
                    romashka.Open -= girl.GirlHandleFlowers;
                    matiolla.Open += girl.GirlHandleFlowers; // якщо будний день - підписуємось на вечірні квіти
                }
                ++day;
                if (day > 7) day -= 7; // для словника потрібно, щоб день був від 1 до 7

                // імітація доби
                Console.WriteLine("\n------- Початок дня -------\n");
                for (int j = 0; j < 5; ++j)
                {
                    if (j == 0)
                    {
                        mySun.OnSunRise();
                        Thread.Sleep(sleepTime);
                    }
                    if (j == 1)
                    {
                        mySun.OnMorning();
                        Thread.Sleep(sleepTime);
                    }
                    if (j == 2)
                    {
                        mySun.OnNoon();
                        Thread.Sleep(sleepTime);
                    }
                    if (j == 3)
                    {
                        mySun.OnAfternoon();
                        Thread.Sleep(sleepTime);
                    }
                    if (j == 4)
                    {
                        mySun.OnSunSet();
                        Thread.Sleep(sleepTime);
                    }
                }
                Console.WriteLine("\n------- Завершення дня -------\n");
                Thread.Sleep(sleepTime*2);

                // Якщо квітка відцвіла свій період, вона відписується
                foreach (Flower f in flowers)
                {
                    if (f.FloweringPeriod == 0)
                    {
                        mySun.Morning -= f.FlowerHandleMorning;
                        mySun.Afternoon -= f.FlowerHandleAfternoon;
                    }
                }
            }
        }
    } 
}