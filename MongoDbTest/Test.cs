using MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbTest
{
    public class Item : Entity
    {
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public int Type { get; set; }
        public string Content { get; set; }

    }
}
