using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;

namespace CathedralProjects.Models
{
    public class Topic
    {
        [BsonId]
        public Guid ID { get; set; }
        public Guid TeacherId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long Date { get; set; }
    }
}