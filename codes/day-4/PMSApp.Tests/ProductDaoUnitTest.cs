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
            //productDao = new ProductDao(inventory);
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
            bool? actual = productDao?.Add(new ProductDto(3, "MacBook Pro", 150000, "new laptop from apple"));
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
                productDao?.Add(new ProductDto(1, "MacBook Pro", 150000, "new laptop from apple"));
            });
        }

        [Test]
        public void GetPositiveTest()
        {
            ProductDto expected = new ProductDto(1, "Dell XPS", 120000, "new 15 inch laptop from dell", 1,new CategoryDto(1, "Laptop"));
            ProductDto? actual = productDao?.Get(1);            
            if(actual != null)
            {
                //Assert.That(actual.Equals(expected));
                Assert.That(actual, Is.EqualTo(expected));
            }
        }
    }
}
