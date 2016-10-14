using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using RepositoryPattern;

namespace UnitTestProject
{
    [TestFixture]
    public class UnitTest2
    {
        IRepository<Storeable> _inMemRepository;

        [SetUp]
        public void SetUp()
        {
            _inMemRepository = new Repository<Storeable>();

        }

        [Test]
        public void GivenARepo_WhenAllItemsCalled_ResultIsTypeStoreable()
        {
            var results = GetAll();

            Assert.IsInstanceOf<IEnumerable<Storeable>>(results);
        }

        [Test]
        public void GiveAnItem_WhenItemAdded_InMemoryListContainsItem()
        {
            var store = CreateStore();
            _inMemRepository.Save(store);

            var allInMemoryData = GetAll();

            Assert.IsTrue(allInMemoryData.Contains(store));
        }

        [Test]
        public void GivenAnItem_WhenDeleted_RemovesAllFromInMemoryList()
        {
            var store = CreateStore();
            _inMemRepository.Save(store);

            _inMemRepository.Delete(2);

            Assert.IsFalse(GetAll().Contains(store));

        }

        [Test]
        public void GivenAnId_WhenFinding_GetsTheItem()
        {
            var store = CreateStore();
            _inMemRepository.Save(store);

            var item = _inMemRepository.FindById(store.Id);

            Assert.AreEqual(store, item);

        }

        private Storeable CreateStore()
        {
            return new Storeable { Id = 1 };
        }

        private IEnumerable<Storeable> GetAll()
        {
            return _inMemRepository.All();

        }

    }
}
