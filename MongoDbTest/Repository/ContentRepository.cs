using MongoDbTest.Model;
using MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbTest.Repository
{
    public class ContentRepository
    {
        private readonly MongoRepository<ContentItem> db = new MongoRepository<ContentItem>();

        public void Save(ContentItem content)
        {
            if (null != content && content.IsValid())
            {
                db.Add(content);

                var storedContent = db.Where(c => c.OwnerId == content.OwnerId && c.Name == content.Name);

                if (null == storedContent)
                    throw new Exception(string.Format("Saving {0} was not succesfull.", content.Name));

                var metadataRepository = new MetadataRepository();
                var metadata = metadataRepository.GetMetadataByOwnerId(content.OwnerId);
                metadataRepository.UpdateContentIndex(metadata, storedContent.FirstOrDefault().Id);
            }
        }

        public IEnumerable<ContentItem> GetContentsByOwnerId(string ownerId)
        {
            return db.Where(c => c.OwnerId == ownerId);
        }
    }
}
