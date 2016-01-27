using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;

namespace CathedralProjects.Models
{
    public class Group
    {
        [BsonId]
        public string ExternalId { get; set; }
        public string Name { get; set; }

        public Group(string id, string name)
        {
            ExternalId = id;
            Name = name;
        }
    }
}