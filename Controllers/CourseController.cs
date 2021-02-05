using HandsOnWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace HandsOnWebAPI.Controllers
{
    public class CourseController : ApiController
    {
        // GET: api/Course

        static List<Course> courses = new List<Course>() {
        new Course() {Id = 1, CourseName="Android",Trainer="Shawn",Fees=12000,
         CourseDescription="Android is a mobile operating system development"},
        new Course() {Id = 2, CourseName="asp.net",Trainer="Kevin",Fees=22000,
         CourseDescription="ASP.Net is a open source web development framework"},
        new Course() {Id = 3, CourseName="JSP",Trainer="Debaratha",Fees=10000,
         CourseDescription="Java server pages is a technology used for web page creations"},
        new Course() {Id = 4, CourseName="Xamarin.forms",Trainer="Mark John",Fees=10000,
         CourseDescription="Xamarin forms are cross platform UI tools"},
        };


        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Course/5
        public HttpResponseMessage Get(string courseName)
        {

            Course course = courses.Find(c => c.CourseName == courseName);

            if(course != null)
            {

                return Request.CreateErrorResponse(HttpStatusCode.OK, course.ToString() );
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Course name not found!!");
            }


        }

        // POST: api/Course
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Course/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Course/5
        public void Delete(int id)
        {
        }
    }
}
