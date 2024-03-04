using PMSApp.Data;
using PMSApp.Entities;

namespace PMSApp.DAL
{
    public class ProductDao
    {
        private readonly Inventory inventory;

        public ProductDao(Inventory inventory)
        {
            this.inventory = inventory;
        }

        public bool Add(Product product)
        {
            try
            {
                var products = inventory.Products;
                Product? found = null;
                if (products.Count() > 0)
                {
                    foreach (var item in products)
                    {
                        if (item.Id == product.Id)
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
                    products.Add(product);
                    return true;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Delete(int productId)
        {
            try
            {
                var products = inventory.Products;
                Product? found = null;
                if (products.Count() > 0)
                {
                    foreach (var item in products)
                    {
                        if (item.Id == productId)
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
                        throw new Exception($"no product with the given id: {productId} found in the inventory");
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

        public bool Update(int productId, Product product)
        {
            try
            {
                var products = inventory.Products;
                Product? found = null;
                if (products.Count() > 0)
                {
                    foreach (var item in products)
                    {
                        if (item.Id == productId)
                        {
                            found = item;
                            break;
                        }
                    }
                    if (found != null)
                    {
                        found.Price = product.Price;
                        found.Description = found.Description;
                        found.Name = product.Name;

                        return true;
                    }
                    else
                        throw new Exception($"no product with the given id: {productId} found in the inventory");
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
        public Product Get(int productId)
        {
            var products = inventory.Products;
            Product? found = null;
            if (products.Count() > 0)
            {
                foreach (var item in products)
                {
                    if (item.Id == productId)
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
                    throw new Exception($"no product with the given id: {productId} found in the inventory");
            }
            else
            {
                throw new Exception("no product records at all in the inventory");
            }
        }
    }
}
