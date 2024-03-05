using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSApp.Entities
{
    public class Category
    {
        private readonly int _id;
        public int Id { get => _id; }
        public string Name { get; set; } = string.Empty;

        public Category()
        {

        }

        public Category(int id, string name)
        {
            _id = id;
            Name = name;
        }
    }
}
