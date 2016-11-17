using KamikazeThinhPhat.Data.Infrastructure;
using KamikazeThinhPhat.Data.Repositories;
using KamikazeThinhPhat.Model.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
            product.Name = "Công trình C";
            product.Alias = "Cong-Trinh-C";
            product.Price = 100000;
            product.Quantity = 3;
            product.CategoryID = 4;
            product.Status = true;
            product.CreatedDate = DateTime.Now;
            var result = productRepository.Add(product);
            unitOfWork.Commit();
            Assert.IsNotNull(result);
            Assert.AreEqual(15, result.ID);
        }
    }
}