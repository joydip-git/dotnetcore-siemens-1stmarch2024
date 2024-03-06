using PMSApp.Data;
using PMSApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSApp.DAL
{
    public class CategoryDao : IDataAccess<Category>
    {
        private readonly IInventory inventory;

        public CategoryDao(IInventory inventory)
        {
            this.inventory = inventory;
        }

        public bool Add(Category data)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Category Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            return inventory.Categories;
        }

        public bool Update(int id, Category data)
        {
            throw new NotImplementedException();
        }
    }
}
