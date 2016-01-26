using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;

namespace CathedralProjects.Models
{
    public class Doument
    {
        [BsonId]
        public Guid ID { get; set; }
        public Guid Author_id { get; set; }
        public Guid Project_id { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public long Date { get; set; }
        public long size { get; set; }
        public string Url { get; set; }
        public long Modification { get; set; }
    }
}