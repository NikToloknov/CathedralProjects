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
        public string TeacherId { get; set; }
        public string Group { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long Date { get; set; }
        public string SubjectId { get; set; }

        public Topic(string teach, string group, string title, string desc, long date, string subject)
        {
            ID = Guid.NewGuid();
            TeacherId = teach;
            Group = group;
            Title = title;
            Description = desc;
            Date = date;
            SubjectId = subject;
        }
    }
}