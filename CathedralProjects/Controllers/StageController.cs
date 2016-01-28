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
    public class StageController : ApiController
    {
        private readonly StageRepository _stageRepository =
            new StageRepository(new MongoProvider("mongodb://localhost:27017", "Student"));

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("stage/addstage")]
        public IHttpActionResult AddStage([FromBody]string search)
        {
            JObject Json = new JObject();
            using (StreamReader sr = new StreamReader(HttpContext.Current.Request.InputStream))
            {
                Json = JsonConvert.DeserializeObject<JObject>(sr.ReadToEnd());
            }

            string Author_id;
            string Project_id;
            string Title;
            string Description;
            bool State;
           
            try
            {
                Author_id = Json.Descendants().OfType<JProperty>().First(p => p.Name == "Author_id").Value.ToString();
                Project_id = Json.Descendants().OfType<JProperty>().First(p => p.Name == "Project_id").Value.ToString();
                Title = Json.Descendants().OfType<JProperty>().First(p => p.Name == "Title").Value.ToString();
                Description = Json.Descendants().OfType<JProperty>().First(p => p.Name == "Description").Value.ToString();
                State = Convert.ToBoolean(Json.Descendants().OfType<JProperty>().First(p => p.Name == "Description").Value);
            }
            catch (System.InvalidOperationException)
            {
                return Content(HttpStatusCode.NotFound, "The request must contain a field query");
            }
            catch (System.FormatException)
            {
                return Content(HttpStatusCode.NotFound, "from and size it must be non-negative integer");
            }

            _stageRepository.AddStage(new Stage(Author_id,Project_id,Title,Description,State,DateTime.Now.Ticks));
            return Ok();
      }
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("stage/complite/{id}")]
        public IHttpActionResult StageComplite(string id)
        {
            _stageRepository.CompleteStage(id);
            return Ok();
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("stage/open/{id}")]
        public IHttpActionResult StageOpen(string id)
        {
            _stageRepository.OpenStage(id);
            return Ok();
        }
    }
}
