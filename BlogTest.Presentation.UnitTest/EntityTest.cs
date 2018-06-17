using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlogTest.Data;
using BlogTest.Data.Model;
using BlogTest.Data.Context;
using BlogTest.Data.Repositories;
using BlogTest.Data.UnitOfWork;

namespace BlogTest.Presentation.UnitTest
{
    [TestClass]
    public class EntityTest
    {
        private BlogContext _dbContext;

        private IUnitOfWork _uow;
        private IRepository<User> _userRepository;
        private IRepository<Category> _categoryRepository;
        private IRepository<Article> _articleRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            _dbContext = new BlogContext();

            _uow = new BlogUnitOfWork(_dbContext);
            _userRepository = new BlogRepository<User>(_dbContext);
            _categoryRepository = new BlogRepository<Category>(_dbContext);
            _articleRepository = new BlogRepository<Article>(_dbContext);

        }

        [TestCleanup]
        public void TestCleanup()
        {
            _dbContext = null;
            _uow.Dispose();
        }

        [TestMethod]
        public void AddUser()
        {
            User user = new User
            {
                FirstName = "Muhammed",
                LastName = "Aras",
                CreatedDate = DateTime.Now,
                Email = "aras1625@hotmail.com",
                Password = "123456"
            };

            _userRepository.Add(user);
            int process = _uow.SaveChanges();

            Assert.AreNotEqual(-1, process);
        }
        [TestMethod]
        public void UpdateUser()
        {
            User user = _userRepository.GetById(1);

            user.FirstName = "Mehmet";

            _userRepository.Update(user);
            int process = _uow.SaveChanges();

            Assert.AreNotEqual(-1, process);
        }

        [TestMethod]
        public void DeleteUser()
        {
            User user = _userRepository.GetById(1);

            _userRepository.Delete(user);
            int process = _uow.SaveChanges();

            Assert.AreNotEqual(-1, process);
        }
    }
}
