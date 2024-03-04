namespace ShapesAreaApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IShape> list = new List<IShape>
            {
                new Circle(12),
                new Triangle(12,3)
            };

            foreach (var item in list)
            {
                Console.WriteLine($"Area of {item.GetType().Name} is {item.CalculateArea()} ");
            }
        }
    }
}
