using PMSApp.Data;
using PMSApp.Entities;

namespace PMSApp.DAL
{
    public class ProductDao : IDataAccess<Product>
    {
        private readonly IInventory inventory;

        public ProductDao(IInventory inventory)
        {
            this.inventory = inventory;
        }

        public bool Add(Product data)
        {
            try
            {
                var products = inventory.Products;
                Product? found = null;
                if (products.Count() > 0)
                {
                    foreach (var item in products)
                    {
                        if (item.Id == data.Id)
                        {
                            found = item;
                            break;
                        }
                    }
                }
                if (found != null)
                {
                    throw new Exception("Product exists");
                }
                else
                {
                    products.Add(data);
                    return true;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var products = inventory.Products;
                Product? found = null;
                if (products.Count() > 0)
                {
                    foreach (var item in products)
                    {
                        if (item.Id == id)
                        {
                            found = item;
                            break;
                        }
                    }
                    if (found != null)
                    {
                        return products.Remove(found);
                    }
                    else
                        throw new Exception($"no product with the given id: {id} found in the inventory");
                }
                else
                {
                    throw new Exception("no product records at all in the inventory");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Product Get(int id)
        {
            var products = inventory.Products;
            Product? found = null;
            if (products.Count() > 0)
            {
                foreach (var item in products)
                {
                    if (item.Id == id)
                    {
                        found = item;
                        break;
                    }
                }
                if (found != null)
                {
                    return found;
                }
                else
                    throw new Exception($"no product with the given id: {id} found in the inventory");
            }
            else
            {
                throw new Exception("no product records at all in the inventory");
            }
        }

        public IEnumerable<Product> GetAll()
        {
            try
            {
                var products = inventory.Products;
                if (products.Count() > 0)
                    return products;
                else
                    throw new Exception("there are no product records in the inventory");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(int id, Product data)
        {
            try
            {
                var products = inventory.Products;
                Product? found = null;
                if (products.Count() > 0)
                {
                    foreach (var item in products)
                    {
                        if (item.Id == id)
                        {
                            found = item;
                            break;
                        }
                    }
                    if (found != null)
                    {
                        found.Price = data.Price;
                        found.Description = data.Description;
                        found.Name = data.Name;

                        return true;
                    }
                    else
                        throw new Exception($"no product with the given id: {id} found in the inventory");
                }
                else
                {
                    throw new Exception("no product records at all in the inventory");
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
