namespace MemoryManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
			try
			{
                DataAccess dataAccess = new DataAccess(@"D:/training/dotnetcore-siemens-1stmarch2024/codes/day-2/MemoryManagement/data.txt");
                dataAccess.Write("my data");
            }
			catch (Exception ex)
			{
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
