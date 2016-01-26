using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;

namespace CathedralProjects.Models
{
    public class Subject
    {
        [BsonId]
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Exam { get; set; }
        public bool Project { get; set; }
    }
}