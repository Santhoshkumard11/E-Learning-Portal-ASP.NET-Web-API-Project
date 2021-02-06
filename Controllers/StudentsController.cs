using HandsOnWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity.Migrations;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace HandsOnWebAPI.Controllers
{
    public class StudentsController : ApiController
    {
        private readonly HandsOnWebAPIContext db = new HandsOnWebAPIContext();
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, db.Students.ToList());
        }

        public HttpResponseMessage Get(int id)
        {

            var result = db.Students.FirstOrDefault(s => s.Id == id);

            if (result != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, result);

            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, $"student with Id {id} not found!!");
            }

        }

        public HttpResponseMessage Put(int id, [FromBody] Student student)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Make sure you have all the model values correct!!");
            }

            db.Entry(student).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, $"Student with the {id} doesn't exist!!");
                }

            }

            return Request.CreateResponse(HttpStatusCode.OK, student);

        }

        public bool StudentExists(int id)
        {

            return db.Students.Count(s => s.Id == id) > 0;
        }


        public HttpResponseMessage Post([FromBody] Student student)
        {

            

            if(!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Fill all the fields of the student");
            }

            try
            {

                db.Students.Add(student);
                db.SaveChanges();
            }
            catch ( Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

            return Request.CreateResponse(HttpStatusCode.Created, student);
        }

    
        public HttpResponseMessage Delete(int id)
        {

            try
            {
                Student queriedStudent = db.Students.FirstOrDefault(s => s.Id == id);

                if (queriedStudent == null)
                {
                   return GenerateResponseMessage(400, $"Student with Id {id} not found!! So not deleted!!");
                }
                else
                {
                    db.Students.Remove(queriedStudent);
                    db.SaveChanges();
                    return GenerateResponseMessage(202, $"Student with Id {id} deleted successfully!!");
                }

            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }


        }
    

        //create a method which will return a response by taking in the status code and message
        /// <summary>
        /// Generate the response for the 
        /// </summary>
        /// <param name="statusCode">Response Status Code</param>
        /// <param name="message"> Message as string or models</param>
        /// <returns>Http response message</returns>
        public HttpResponseMessage GenerateResponseMessage(int statusCode, object message)
        {

            var statusCodeType = new object() ;

            switch (statusCode)
            {
                case  200:{statusCodeType = HttpStatusCode.OK;break; }
                case  202:{statusCodeType = HttpStatusCode.Accepted;break; }
                case  400:{statusCodeType = HttpStatusCode.BadRequest;break; }
                
                default:
                    break;
            }

            return Request.CreateResponse((HttpStatusCode)statusCodeType, message);

        }
    
    }
}
