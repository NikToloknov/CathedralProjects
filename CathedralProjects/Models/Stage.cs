using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;

namespace CathedralProjects.Models
{
    public class Stage
    {
        [BsonId]
        public string ID { get; set; }
        public string AuthorId { get; set; }
        public string ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }
        public long Date { get; set; }

        public Stage(string author, string project, string title, string descript, bool state, long data)
        {
            ID = Guid.NewGuid().ToString();
            AuthorId = author;
            ProjectId = project;
            Title = title;
            Description = descript;
            State = state;
            Date = data;
        }
    }
}