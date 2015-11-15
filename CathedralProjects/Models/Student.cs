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
        public string MiddleName { get; set; }
        public string GroupId { get; set; }

    }
}