using MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbTest.Model
{
    public class Metadata : Entity
    {
        public string Owner { get; set; }

        public DateTime Created { get; private set; }

        public string ContentIndex { get; set; }

        public Metadata()
        {
            Created = DateTime.UtcNow;
        }

        public bool IsValid()
        {
            var valid = true;

            if (string.IsNullOrEmpty(Owner))
            {
                valid = false;
                //ToDo: log
            }

            return valid;
        }
    }

    public enum ContentType
    {
        None = 0,
        Text,
        PictureJpg,
        Pdf,
        DocumentWord,
        DocumentExcel,
        Document
    }

    public class ContentItem : Entity
    {
        public string OwnerId { get; set; }
        public string Name { get; set; }
        public ContentType Type { get; set; }
        public string Content { get; set; }
        public DateTime Modified { get; set; }
        
        public ContentItem(string ownerId)
        {
            Modified = DateTime.UtcNow;
            Type = ContentType.None;
            OwnerId = ownerId;
        } 

        public bool IsValid()
        {
            var valid = true;

            if (string.IsNullOrEmpty(OwnerId))
            {
                valid = false;
                //ToDo: log
            }

            if (string.IsNullOrEmpty(Name))
            {
                valid = false;
                //ToDo: log
            }

            if (Type == ContentType.None)
            {
                valid = false;
                //ToDo: log
            }

            if (string.IsNullOrEmpty(Content))
            {
                valid = false;
                //ToDo: log
            }

            return valid;
        }
    }
}
