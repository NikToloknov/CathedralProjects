using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;

namespace CathedralProjects.Models
{
    public class Project
    {
        [BsonId]
        public Guid ID { get; set; }
        public string StudentId { get; set; }
        public string TeacherId { get; set; }
        public string TopicId { get; set; }
        public string Lable { get; set; }
        public string Description { get; set; }
        public string GitHubRepository { get; set; }
        public int Assesment { get; set; }
        public int CommanAssesmaent { get; set; }
        public long DateFinally { get; set; }
        public long DateJoin { get; set; }
        public string Type { get; set; }
        public string Subject { get; set; }
    }
}