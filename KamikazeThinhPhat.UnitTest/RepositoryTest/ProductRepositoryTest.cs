using KamikazeThinhPhat.Data.Infrastructure;
using KamikazeThinhPhat.Data.Repositories;
using KamikazeThinhPhat.Model.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KamikazeThinhPhat.UnitTest.RepositoryTest
{
    [TestClass]
    public class ProductRepositoryTest
    {
        private IDbFactory dbFactory;
        private IUnitOfWork unitOfWork;
        private IProductRepository productRepository;

        [TestInitialize]
        public void Initialize()
        {
            dbFactory = new DbFactory();
            productRepository = new ProductRepository(dbFactory);
            unitOfWork = new UnitOfWork(dbFactory);
        }

        [TestMethod]
        public void Product_Repository_Create()
        {
            Product product = new Product();
            product.Name = "Công trình A";
            product.Alias = "Cong-Trinh-A";
            product.Price = 60000;
            product.Quantity = 30;
            product.CategoryID = 4;
            product.Status = true;
            var result = productRepository.Add(product);
            unitOfWork.Commit();
            Assert.IsNotNull(result);
            Assert.AreEqual(13, result.ID);
        }
    }
}