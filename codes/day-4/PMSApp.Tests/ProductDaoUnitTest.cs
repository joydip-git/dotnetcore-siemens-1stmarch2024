using NUnit.Framework.Legacy;
using PMSApp.DAL;
using PMSApp.Data;
using PMSApp.Entities;

namespace PMSApp.Tests
{
    [TestFixture]
    public class ProductDaoUnitTest
    {
        private SiemensDbContext inventory;
        private ProductDao? productDao;

        [SetUp]
        public void SetUp()
        {
            //inventory = new SiemensDbContext();
            //productDao = new ProductDao(inventory);
        }
        [TearDown]
        public void TearDown()
        {
            productDao = null;
            inventory.Dispose();
        }

        [Test]
        public void AddPositiveTest()
        {
            bool? actual = productDao?.Add(new ProductCreateDto("MacBook Pro", 150000, "new laptop from apple"));
            if (actual != null)
            {
                Assert.That(actual, Is.EqualTo(true));
            }
        }

        [Test]
        public void AddExceptionFlowTest()
        {
            Assert.Throws<Exception>(() =>
            {
                productDao?.Add(new ProductCreateDto("MacBook Pro", 150000, "new laptop from apple"));
            });
        }

        [Test]
        public void GetPositiveTest()
        {
            ProductReadDto expected = new ProductReadDto(1, "Dell XPS", 120000, "new 15 inch laptop from dell", 1);
            ProductReadDto? actual = productDao?.Get(1);
            if (actual != null)
            {
                Assert.That(actual, Is.EqualTo(expected));
            }
        }
    }
}
