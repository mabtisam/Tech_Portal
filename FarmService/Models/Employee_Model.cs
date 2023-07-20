using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnicalService.Models
{
    public class Employee_Model
    {
        public int Coperation { get; set; }
        public int Employee_Id { get; set; }
        public string Employee_Name { get; set; }
        public string Employee_Pic { get; set; }
        public int Department_Id { get; set; }
        public int Designation_Id { get; set; }
        public  string CNIC { get; set; }
        public decimal Employee_Salary { get; set; }
        public int Is_Active { get; set; }
        

    }
}