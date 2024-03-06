﻿using PMSApp.DAL;
using PMSApp.Entities;

namespace PMSApp.BL
{
    public class ProductBO : IProductBusinessComponent
    {
        private readonly IDataAccess<Product> _dao;

        public ProductBO(IDataAccess<Product> dao)
        {
            _dao = dao;
        }

        public Product Fetch(int id)
        {
            try
            {
                return _dao.Get(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Product> FetchAll(int choice)
        {
            IEnumerable<Product>? products = null;
            try
            {
                switch (choice)
                {
                    case 0:
                        products = _dao.GetAll().OrderBy(p => p.Id);
                        break;

                    case 1:
                        products = _dao.GetAll().OrderBy(p => p.Name);
                        break;

                    case 2:
                        products = _dao.GetAll().OrderBy(p => p.Price);
                        break;

                    default:
                        products = _dao.GetAll().OrderBy(p => p.Id);
                        break;
                }
                return products;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Product> FetchAll()
        {
            try
            {
                return _dao.GetAll().OrderBy(p => p.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Product> FilterByName(string productName)
        {
            try
            {
                var all = _dao.GetAll().OrderBy(p => p.Id);
                var filteredResult = all.Where(p => p.Name.Contains(productName));
                if (filteredResult.Any())
                {
                    return filteredResult;
                }
                else
                    return all;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Insert(Product entity)
        {
            try
            {
                if (entity != null)
                {
                    
                    var lastProduct = FetchAll().Last();
                    var newId = 1;
                    if (lastProduct != null)
                    {
                        newId = lastProduct.Id + 1;
                    }

                    var updated = new Product(newId, entity.Name, entity.Price, entity.Description);
                    return _dao.Add(updated);
                }
                else
                    throw new NullReferenceException("null reference has been passed");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Modify(int id, Product entity)
        {
            try
            {
                if(entity != null)
                {
                    return _dao.Update(id, entity);
                }else
                    throw new NullReferenceException("null reference has been passed");
            }
            catch(Exception) { throw; }
        }

        public bool Remove(int id)
        {
            try
            {
               return _dao.Delete(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
