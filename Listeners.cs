namespace SunEvents
{
    public class Flower
    {
        int SleepTime = 1000; //оголошено в кожному класі для виводу в консоль із перервою

        public string Name { get; set; }
        public string Type { get; set; }
        public uint FloweringPeriod { get; set; }

        public event EventHandler Open;

        public void OnOpen()
        {
            Open?.Invoke(this, EventArgs.Empty);
        }

        public Flower(string name, string type, uint floweringperiod)
        {
            Name = name;
            Type = type;
            FloweringPeriod = floweringperiod;
        }

        public void FlowerHandleMorning(object sender, EventArgs arg)
        {
            if (sender is Sun)
            {
                Thread.Sleep(SleepTime);

                if (FloweringPeriod == 0) { } // термін цвітіння завершився
                else
                {
                    if (Type == "денна")
                    {
                        Console.WriteLine($"Квітка {Name} розпустилася");
                        OnOpen();
                    }
                    else
                    {
                        FloweringPeriod -= 1;
                        Console.WriteLine($"Квітка {Name} закрилася, період цвітіння: {FloweringPeriod}");
                    }
                }
            }
        }

        public void FlowerHandleAfternoon(object sender, EventArgs arg)
        {
            if (sender is Sun)
            {
                Thread.Sleep(SleepTime);

                if (FloweringPeriod == 0) { } // термін цвітіння завершився
                else
                {
                    if (Type == "вечірня")
                    {
                        Console.WriteLine($"Квітка {Name} розпустилася");
                        OnOpen();
                    }
                    else
                    {
                        FloweringPeriod -= 1;
                        Console.WriteLine($"Квітка {Name} закрилася, період цвітіння: {FloweringPeriod}");
                    }
                }
            }
        }
    }

    public class Bee
    {
        int SleepTime = 1000;

        public void BeeHandleSunRise(object sender, EventArgs arg)
        {
            if (sender is Sun)
            {
                Thread.Sleep(SleepTime);

                Console.WriteLine("Бджілка вилетіла по нектар");
            }
        }

        public void BeeHandleSunSet(object sender, EventArgs arg)
        {
            if (sender is Sun)
            {
                Thread.Sleep(SleepTime);

                Console.WriteLine("Бджілка повернулася");
            }
        }

        public void BeeHandleOpenFlowers(object sender, EventArgs arg)
        {
            if (sender is Flower)
            {
                Thread.Sleep(SleepTime);

                Flower f = sender as Flower;
                Console.WriteLine($"Бджілка: Я зібрала нектар із такої квітки: {f.Name}");
            }
        }
    }

    public class NightButterfly
    {
        int SleepTime = 1000;

        public void NightButterflyHandleSunRise(object sender, EventArgs arg)
        {
            if (sender is Sun)
            {
                Thread.Sleep(SleepTime);

                Console.WriteLine("Метелик повернувся");
            }
        }

        public void NightButterflyHandleSunSet(object sender, EventArgs arg)
        {
            if (sender is Sun)
            {
                Thread.Sleep(SleepTime);

                Console.WriteLine("Метелик вилетів");
            }
        }

        public void ButterflyHandleOpenFlowers(object sender, EventArgs arg)
        {
            if (sender is Flower)
            {
                Thread.Sleep(SleepTime);

                Flower f = sender as Flower;
                Console.WriteLine($"Метелик: Я відвідав таку квітку: {f.Name}");
            }
        }
    }

    public class Girl
    {
        int SleepTime = 1000;

        public string Name { get; set; }
        public Girl(string name) { Name = name; }

        public void GirlHandleFlowers(object sender, EventArgs arg)
        {
            if (sender is Flower)
            {
                Thread.Sleep(SleepTime);

                Flower f = sender as Flower;
                Console.WriteLine($"{Name}: я оглядаю квітку: {f.Name}, роблю селфі і вдихаю пахощі");
            }
        }
    }
}
