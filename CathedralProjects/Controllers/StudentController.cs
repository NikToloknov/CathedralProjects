using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CathedralProjects.Providers;
using CathedralProjects.Repository;
using Microsoft.AspNet.Identity;

namespace CathedralProjects.Controllers
{
    [Authorize]
    public class StudentController : ApiController
    {
        private readonly StudentRepository _studentRepository = 
            new StudentRepository(new MongoProvider("mongodb://localhost:27017", "Student"));

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("student/profile")]
        public IHttpActionResult GetStudentInfo()
        {
            string ids =  User.Identity.GetUserId();
            var result = _studentRepository.GetStudent(ids);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
    }
}
