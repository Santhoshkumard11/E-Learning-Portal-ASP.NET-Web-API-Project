using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HandsOnWebAPI.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }

        public string  LastName { get; set; }

        public float Salary { get; set; }

        //Foreign Key
        public int DepartmentId { get; set; }
        //Navigation Property
        public Decimal Department { get; set; }
    }
}