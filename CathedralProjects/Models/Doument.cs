using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;

namespace CathedralProjects.Models
{
    public class Document
    {
        [BsonId]
        public Guid ID { get; set; }
        public string Author_id { get; set; }
        public string Project_id { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public long Date { get; set; }
        public long size { get; set; }
        public string Url { get; set; }
        public long Modification { get; set; }

        public Document(string author, string project, string type, 
            string title, long date, long size, string url,long modif)
        {

        }
    }
}