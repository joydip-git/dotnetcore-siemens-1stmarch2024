using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading.Channels;

namespace GCDemo
{
    internal class Product : IDisposable
    {
        ~Product()
        {
            Console.WriteLine("what ???");
            if (_writer == null)
                Console.WriteLine("NULL");

            _writer.Flush();
            _writer.Close();
            Console.WriteLine("writer is disposed off");
        }

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        private StreamWriter _writer;
        public void WriteToFile()
        {
            string filePath = @"D:/training/dotnetcore-siemens-1stmarch2024/codes/day-2/GCDemo/data.txt";
            _writer = new StreamWriter(filePath, true);
            _writer.WriteLine(this.Id + "," + this.Name);


            //using (_writer = new StreamWriter(filePath, true)
            //)
            //{
            //    _writer.WriteLine(this.Id + "," + this.Name);
            //}
        }

        public void Dispose()
        {
            //GC.SuppressFinalize(this);
            Console.WriteLine("Dispose Thread Id:  " + System.Threading.Thread.CurrentThread.ManagedThreadId);
            _writer.Flush();
            _writer.Close();
            Console.WriteLine("writer is disposed off");
        }
        public override string ToString()
        {
            //return this.GetType().FullName;
            return $"{Id}, {Name}";
        }
    }
}
