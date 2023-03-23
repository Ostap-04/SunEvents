namespace SunEvents
{
    public class Sun
    {
        public event EventHandler SunRise;
        public event EventHandler Morning;
        public event EventHandler Noon;
        public event EventHandler Afternoon;
        public event EventHandler SunSet;

        public void OnSunRise()
        {
            Console.WriteLine("*** Сонце зійшло ***");
            SunRise?.Invoke(this, EventArgs.Empty);
        }

        public void OnMorning()
        {
            Console.WriteLine("*** Ранок ***");
            Morning?.Invoke(this, EventArgs.Empty);
        }

        public void OnNoon()
        {
            Console.WriteLine("*** Полудень ***");
            Noon?.Invoke(this, EventArgs.Empty);
        }

        public void OnAfternoon()
        {
            Console.WriteLine("*** Надвечір'я ***");
            Afternoon?.Invoke(this, EventArgs.Empty);
        }

        public void OnSunSet()
        {
            Console.WriteLine("*** Сонце зайшло ***");
            SunSet?.Invoke(this, EventArgs.Empty);
        }
    }
}
