using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoRepository;
using MongoDbTest.Model;
using System.Linq;
using MongoDbTest.Repository;

namespace UnitTests
{
    [TestClass]
    public class MetadataTest
    {
        [TestMethod]
        public void AddMetadata_Test()
        {
            var db = new MongoRepository<Metadata>();

            var metadata = new Metadata { Owner = "fjarai@msn.com", ContentIndex = "Empty!" };

            db.Add(metadata);

            var result = db.ToList();

            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AddDuplicateMetadata_Test()
        {
            var metadataRepository = new MetadataRepository();

            var metadata = new Metadata { Owner = "fjarai@msn.com", ContentIndex = "Empty!" };

            metadataRepository.Save(metadata);
        }


    }
}
