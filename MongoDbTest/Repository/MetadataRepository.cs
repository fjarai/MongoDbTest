using MongoDbTest.Model;
using MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbTest.Repository
{
    public class MetadataRepository
    {
        private readonly MongoRepository<Metadata> db = new MongoRepository<Metadata>();

        public void Save(Metadata metadata)
        {
            if (null != metadata && metadata.IsValid())
            {
                if (null != GetMetadataByOwner(metadata.Owner))
                    throw new Exception(string.Format("{0} has already a record.", metadata.Owner));

                db.Add(metadata);
            }
        }

        public Metadata GetMetadataByOwner(string owner)
        {
            return db.Single(m => m.Owner == owner);
        }

        public Metadata GetMetadataByOwnerId(string ownerId)
        {
            return db.Single(m => m.Id == ownerId);
        }

        public void UpdateContentIndex(Metadata metadata, string contentId)
        {
            if (null == metadata || string.IsNullOrEmpty(contentId))
                return;
            
            metadata.ContentIndex += (!string.IsNullOrEmpty(metadata.ContentIndex) ? "," : "") + contentId;

            db.Update(metadata);
        }


    }
}
