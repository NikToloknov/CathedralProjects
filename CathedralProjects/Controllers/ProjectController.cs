using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using CathedralProjects.Models;
using CathedralProjects.Providers;
using CathedralProjects.Repository;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CathedralProjects.Controllers
{
    public class ProjectController : ApiController
    {
        private readonly ProjectRepository _projectRepository =
            new ProjectRepository(new MongoProvider("mongodb://localhost:27017", "Student")); 
        /// <summary>
        /// Добавить тему
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("project/addproject")]
        public IHttpActionResult AddTopic([FromBody]string search)
        {
            JObject Json = new JObject();
            using (StreamReader sr = new StreamReader(HttpContext.Current.Request.InputStream))
            {
                Json = JsonConvert.DeserializeObject<JObject>(sr.ReadToEnd());
            }

            string studentId;
            string topicId;

            try
            {
                studentId = Json.Descendants().OfType<JProperty>().First(p => p.Name == "studentId").Value.ToString();
                topicId = Json.Descendants().OfType<JProperty>().First(p => p.Name == "topicId").Value.ToString();
            }
            catch (System.InvalidOperationException)
            {
                return Content(HttpStatusCode.NotFound, "The request must contain a all field");
            }

            _projectRepository.addProject(topicId, studentId);
            return Ok();
        }
        [System.Web.Http.Route("stage/complite/{id}")]
        public async Task<IHttpActionResult> AddFile()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                return BadRequest();
            }
            var provider = new MultipartMemoryStreamProvider();
            // путь к папке на сервере
            string root = System.Web.HttpContext.Current.Server.MapPath("~/Files/");
            await Request.Content.ReadAsMultipartAsync(provider);

            foreach (var file in provider.Contents)
            {
                var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
                byte[] fileArray = await file.ReadAsByteArrayAsync();

                using (System.IO.FileStream fs = new System.IO.FileStream(root + filename, System.IO.FileMode.Create))
                {
                    await fs.WriteAsync(fileArray, 0, fileArray.Length);
                }
            }
            return Ok("файлы загружены");
        }
    }
}
