using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutstandingPersonApp
{
    public abstract class Person
    {
        public string Name { get; set; } = string.Empty;
        public Person()
        {
            
        }

        public Person(string name)
        {
            Name = name;
        }

        public abstract bool IsOutstanding();
    }
}
