using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using CathedralProjects.Models;
using CathedralProjects.Providers;
using CathedralProjects.Repository;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CathedralProjects.Controllers
{
    [Authorize]
    public class TopicController : ApiController
    {
        private readonly TopicRepository _topicRepository =
            new TopicRepository(new MongoProvider("mongodb://localhost:27017", "Student"));

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("topic/addtopic")]
        public IHttpActionResult AddTopic([FromBody]string search)
        {
            JObject Json = new JObject();
            using (StreamReader sr = new StreamReader(HttpContext.Current.Request.InputStream))
            {
                Json = JsonConvert.DeserializeObject<JObject>(sr.ReadToEnd());
            }

            string TeacherId;
            string Group;
            string Title;
            string Description;
            long Date;
            string SubjectId;
           
            try
            {
                TeacherId = Json.Descendants().OfType<JProperty>().First(p => p.Name == "TeacherId").Value.ToString();
                Group = Json.Descendants().OfType<JProperty>().First(p => p.Name == "Group").Value.ToString();
                Title = Json.Descendants().OfType<JProperty>().First(p => p.Name == "Title").Value.ToString();
                Description = Json.Descendants().OfType<JProperty>().First(p => p.Name == "Description").Value.ToString();
                Date = Convert.ToInt64(Json.Descendants().OfType<JProperty>().First(p => p.Name == "Date").Value);
                SubjectId = Json.Descendants().OfType<JProperty>().First(p => p.Name == "SubjectId").Value.ToString();
            }
            catch (System.InvalidOperationException)
            {
                return Content(HttpStatusCode.NotFound, "The request must contain a field query");
            }
            catch (System.FormatException)
            {
                return Content(HttpStatusCode.NotFound, "from and size it must be non-negative integer");
            }

            _topicRepository.AddTopic(new Topic(TeacherId, Group, Title, Description, Date, SubjectId));
            return Ok();
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("topic/gettopics/{groupId}")]
        public IHttpActionResult StageOpen(string groupId)
        {
            var res = _topicRepository.GetAllTopic(groupId);
            if (res != null)
            {
                return Ok(res);
            }
            return NotFound();
        }
    }
}
