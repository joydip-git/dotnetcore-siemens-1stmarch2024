//static import
using static GenericApp.Addition;
using static System.Console;

namespace GenericApp
{
    class Program
    {
        static List<int> Filter(List<int> list)
        {
            List<int> result = new List<int>();
            foreach (var item in list)
            {
                if (item % 2 == 0)
                    result.Add(item);
            }
            return result;
        }
        static void Main()
        {
            //collection initializer
            List<int> numbers = new List<int> { 0, 3, 2, 5, 7, 4, 9, 6, 8, 1 };
            List<int> evenNumbers = Filter(numbers);
            List<int> oddNumbers = Filter(numbers);
            foreach (var item in evenNumbers)
            {
                Console.WriteLine(item);
            }
            foreach (var item in oddNumbers)
            {
                Console.WriteLine(item);
            }

            WriteLine("Hello, World!");
            Add<int, long>(12, 13);
            Add<int>(12, 13);
            //Add<string>("joydip","mondal");
            Calculation<int> calculation = new Calculation<int>();

            Assistant ramesh = new Assistant();
            Trainer joydip = new Trainer(ramesh);
            joydip.RaiseRequest();
        }
    }

    class Trainer
    {
        private readonly Assistant _assistant;
        public Trainer(Assistant assistant)
        {
            _assistant = assistant;
        }
        public void RaiseRequest()
        {
            //"pass ref to GetMarker method"
            Requirements requirements = new Requirements();
            ReqDel markerDel = new ReqDel(requirements.GetMarkers);
            _assistant.HelpTrainer(markerDel);
        }
    }
    class Assistant
    {
        public string HelpTrainer(ReqDel reqDel)
        {
            return reqDel.Invoke(2);
        }
    }

    delegate string ReqDel(int x);

    class Requirements
    {
        public string GetMarkers(int count)
        {
            return $"got {count} markers";
        }
        public string GetProjectorRemote(int count)
        {
            return $"got {count} remote";
        }
    }
}
