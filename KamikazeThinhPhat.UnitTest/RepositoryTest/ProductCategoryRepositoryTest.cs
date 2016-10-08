using KamikazeThinhPhat.Data.Infrastructure;
using KamikazeThinhPhat.Data.Repositories;
using KamikazeThinhPhat.Model.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace KamikazeThinhPhat.UnitTest.RepositoryTest
{
    [TestClass]
    public class ProductCategoryRepositoryTest
    {
        private IDbFactory dbFactory;
        private IProductCategoryRepository objRepository;
        private IUnitOfWork unitOfWork;

        [TestInitialize]
        public void Initialize()
        {
            dbFactory = new DbFactory();
            objRepository = new ProductCategoryRepository(dbFactory);
            unitOfWork = new UnitOfWork(dbFactory);
        }

        [TestMethod]
        public void ProductCategory_Repository_GetAll()
        {
            var list = objRepository.GetAll().ToList();
            Assert.AreEqual(2, list.Count);
        }

        [TestMethod]
        public void ProductCategory_Repository_Create()
        {
            ProductCategory productCategory = new ProductCategory();
            productCategory.Name = "Khảo Sát Công Trình";
            productCategory.Alias = "khao-sat-cong-trinh";
            productCategory.Status = true;

            var result = objRepository.Add(productCategory);
            unitOfWork.Commit();

            Assert.IsNotNull(result);
            Assert.AreEqual(9, result.ID);
        }
    }
}