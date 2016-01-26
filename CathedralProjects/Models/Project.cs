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
        public Guid StudentId { get; set; }
        public Guid TeacherId { get; set; }
        public Guid TopicId { get; set; }
        public string Description { get; set; }
        public List<Comment> Comments { get; set; }
        public string GitHubRepository { get; set; }
        public List<Stage> Stages { get; set; }
        public int Assesment { get; set; }
        public int CommanAssesmaent { get; set; }
        public List<CathedralProjects.Models.Doument> Documents { get; set; }
        public long DateFinally { get; set; }
        public string Type { get; set; }
        public Guid Subject { get; set; }
    }
}