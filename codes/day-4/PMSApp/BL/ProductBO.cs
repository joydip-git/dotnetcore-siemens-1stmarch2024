using PMSApp.DAL;
using PMSApp.Entities;

namespace PMSApp.BL
{
    public class ProductBO : IProductBusinessComponent
    {
        private readonly IDataAccess<ProductCreateDto, ProductReadDto> _dao;

        public ProductBO(IDataAccess<ProductCreateDto, ProductReadDto> dao)
        {
            _dao = dao;
        }

        public ProductReadDto Fetch(int id)
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

        public IEnumerable<ProductReadDto> FetchAll(int choice)
        {
            IEnumerable<ProductReadDto>? products = null;
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

        public IEnumerable<ProductReadDto> FetchAll()
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

        public IEnumerable<ProductReadDto> FilterByName(string productName)
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

        public bool Insert(ProductCreateDto entity)
        {
            try
            {
                if (entity != null)
                {
                    return _dao.Add(entity);
                }
                else
                    throw new NullReferenceException("null reference has been passed");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Modify(int id, ProductCreateDto entity)
        {
            try
            {
                if (entity != null)
                {
                    return _dao.Update(id, entity);
                }
                else
                    throw new NullReferenceException("null reference has been passed");
            }
            catch (Exception) { throw; }
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
