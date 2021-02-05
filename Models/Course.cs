using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HandsOnWebAPI.Models
{
    public class Course
    {

        public int Id { get; set; }

        public string CourseName { get; set; }

        public string Trainer { get; set; }

        public float Fees { get; set; }
        public string CourseDescription { get; set; }

    }
}