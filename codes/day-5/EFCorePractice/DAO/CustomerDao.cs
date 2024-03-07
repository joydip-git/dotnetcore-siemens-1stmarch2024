using EFCorePractice.DTOs;
using EFCorePractice.Repository;
using Microsoft.EntityFrameworkCore;

namespace EFCorePractice.DAO
{
    public class CustomerDao : ICustomerDao<CustomerCreateDto,CustomerReadDto>
    //: IDisposable
    {
        //private OrderCustomerDbContext db;
        //public CustomerDao()
        //{
        //    db = new OrderCustomerDbContext();
        //}
        //public void Dispose()
        //{
        //    db.Dispose();
        //}
        private OrderCustomerDbContext db;
        public CustomerDao(OrderCustomerDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<CustomerReadDto> GetAll()
        {
            DbSet<Customer> customers = db.Customers;
            var list = customers.Select(
                c => new CustomerReadDto { Id = c.Id, Name = c.Name, MailId = c.MailId, Mobile = c.Mobile }
                ).ToList();

            return list;
        }
        public CustomerReadDto Get(int id)
        {
            DbSet<Customer> customers = db.Customers;
            Customer found = customers.Where(c => c.Id == id).First();
            if (found != null)
            {
                return new CustomerReadDto { Id = found.Id, Name = found.Name, MailId = found.MailId, Mobile = found.Mobile };
            }
            else
                throw new NullReferenceException("no customer found");
        }
        public bool Add(CustomerCreateDto customer)
        {
            db.Customers.Add(new Customer { MailId = customer.MailId, Name = customer.Name, Mobile = customer.Mobile });
            int addRes = db.SaveChanges();
            return addRes > 0;
        }
        public bool Delete(int id)
        {
            var found = db.Customers.Where(c => c.Id == 4).First();
            if (found != null)
            {
                db.Customers.Remove(found);
                int deleteRes = db.SaveChanges();
                return deleteRes > 0;
            }
            else
                throw new NullReferenceException("no customer found");

        }

        public bool Update(int id, CustomerCreateDto customer)
        {
            var found = db.Customers.Where(c => c.Id == id).First();
            if (found != null)
            {
                found.Name = customer.Name;
                found.MailId = customer.MailId;
                found.Mobile = customer.Mobile;

                int updateRes = db.SaveChanges();
                return updateRes > 0;
            }
            else
                throw new NullReferenceException("no customer found");
        }
    }
}
