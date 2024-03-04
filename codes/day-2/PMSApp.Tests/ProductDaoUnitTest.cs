using NUnit.Framework.Legacy;
using PMSApp.DAL;
using PMSApp.Data;
using PMSApp.Entities;

namespace PMSApp.Tests
{
    [TestFixture]
    public class ProductDaoUnitTest
    {
        private Inventory? inventory;
        private ProductDao? productDao;

        [SetUp]
        public void SetUp()
        {
            inventory = new Inventory();
            productDao = new ProductDao(inventory);
        }
        [TearDown]
        public void TearDown()
        {
            productDao = null;
            inventory = null;
        }

        [Test]
        public void AddPositiveTest()
        {
            bool? actual = productDao?.Add(new Product(3, "MacBook Pro", 150000, "new laptop from apple"));
            if (actual != null)
            {
                //Assert.That(actual, Is.True);

                ClassicAssert.AreEqual(true, actual);
            }
        }

        [Test]
        public void AddExceptionFlowTest()
        {            
            Assert.Throws<Exception>(() =>
            {
                productDao?.Add(new Product(1, "MacBook Pro", 150000, "new laptop from apple"));
            });
        }

        [Test]
        public void GetPositiveTest()
        {
            Product expected = new Product(1, "Dell XPS", 120000, "new 15 inch laptop from dell");
            Product? actual = productDao?.Get(1);            
            if(actual != null)
            {
                ClassicAssert.AreEqual(expected, actual);
            }
        }
    }
}
