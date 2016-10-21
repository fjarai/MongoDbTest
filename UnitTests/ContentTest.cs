using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDbTest.Repository;
using MongoDbTest.Model;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class ContentTest
    {
        [TestMethod]
        public void SaveContent_Test()
        {
            var metadataRepository = new MetadataRepository();
            var contentRepository = new ContentRepository();

            var metadata = metadataRepository.GetMetadataByOwner("fjarai@msn.com");
            var content = new ContentItem(metadata.Id)
            {
                Name = "Lexus ES-250",
                Type = ContentType.Text,
                Content = "Plate: ???, Year: 2014"               
            };

            contentRepository.Save(content);
            
            var reterivedContent = contentRepository.GetContentsByOwnerId(metadata.Id);

            Assert.AreEqual(3, reterivedContent.Count());
        }
    }
}
