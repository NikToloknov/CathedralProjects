using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;

namespace CathedralProjects.Models
{
    public class Comment
    {
        [BsonId]
        public Guid ID { get; set; }
        public Guid Author_id { get; set; }
        public Guid Project_id { get; set; }
        public string Text { get; set; }
        public long Date { get; set; }
    }
}