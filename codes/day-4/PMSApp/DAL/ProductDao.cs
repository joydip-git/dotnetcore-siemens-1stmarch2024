using PMSApp.Data;
using PMSApp.Entities;

namespace PMSApp.DAL
{
    public class ProductDao : IDataAccess<ProductCreateDto, ProductReadDto>
    {
        private readonly SiemensDbContext inventory;

        public ProductDao(SiemensDbContext inventory)
        {
            this.inventory = inventory;
        }

        public bool Add(ProductCreateDto data)
        {
            try
            {
                var products = inventory.Products;
                Product p = new Product
                {
                    Name = data.Name,
                    Description = data.Description,
                    Price = data.Price,
                    CategoryId = data.CategoryId
                };
                products.Add(p);
                var res = inventory.SaveChanges();
                return res > 0;
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
                    found = products.Where(p => p.Id == id).First();
                    if (found != null)
                    {
                        products.Remove(found);
                        return inventory.SaveChanges() > 0;
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

        public ProductReadDto Get(int id)
        {
            var products = inventory.Products;
            Product? found = null;
            if (products.Count() > 0)
            {
                found = products.Where(p => p.Id == id).First();
                if (found != null)
                {
                    return new ProductReadDto(found.Id, found.Name, found.Price, found.Description, found.CategoryId);
                }
                else
                    throw new Exception($"no product with the given id: {id} found in the inventory");
            }
            else
            {
                throw new Exception("no product records at all in the inventory");
            }
        }

        public IEnumerable<ProductReadDto> GetAll()
        {
            try
            {
                var products = inventory.Products;
                if (products.Count() > 0)
                {
                    return products.Select(
                         p => new ProductReadDto(p.Id, p.Name, p.Price, p.Description, p.CategoryId, null)
                         );
                }

                else
                    throw new Exception("there are no product records in the inventory");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(int id, ProductCreateDto data)
        {
            try
            {
                var products = inventory.Products;
                Product? found = null;
                if (products.Count() > 0)
                {
                    found = products.Where(p => p.Id == id).First();
                    if (found != null)
                    {
                        found.Price = data.Price;
                        found.Description = data.Description;
                        found.Name = data.Name;
                        found.CategoryId = data.CategoryId;

                        return inventory.SaveChanges() > 0;
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
