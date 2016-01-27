using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.GeoJsonObjectModel;
using MongoDB.Shared;

namespace CathedralProjects.Models
{
    public class Student
    {
        [BsonId]
        public string ExternalId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronomic { get; set; }
        public string GroupId { get; set; }
        public string Email { get; set; }
        public string Github { get; set; }

        public Student(string id, string name, string surname,
            string patronomic, string gropId, string email, string GitHub)
        {
            this.ExternalId = id;
            this.Name = name;
            this.Surname = surname;
            this.Patronomic = patronomic;
            this.Email = email;
            this.GroupId = gropId;
            this.Github = GitHub;
        }
    }
}