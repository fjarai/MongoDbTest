using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoRepository;
using MongoDbTest;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var db = new MongoRepository<Item>();

            var item = new Item
            {
                Name = "First",
                Created = DateTime.Now,
                Type = 1,
                Content = "Empty for noiw!"
            };

            db.Add(item);

            var data = db.ToList();

            Assert.IsTrue(data.Any());
        }
    }
}
