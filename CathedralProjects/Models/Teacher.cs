using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;

namespace CathedralProjects.Models
{
    public class Teacher
    {
        [BsonId]
        public string ExternalId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronomic { get; set; }
        public string Email { get; set; }
        public string Cathedral { get; set; }
       // public List<Subjects> Subjects { get; set; }
    }
}