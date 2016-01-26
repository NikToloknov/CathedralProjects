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
        public Guid ID { get; set; }
        public string Name { get; set; }
        public List<Subject> Subjects { get; set; }
    }
}