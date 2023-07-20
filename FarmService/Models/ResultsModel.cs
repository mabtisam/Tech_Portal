using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Web;
using TechnicalService.Models;


namespace TechnicalService.Models
{

    public class Result
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }

    public class Department_Model_Return
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public Department_Model Department_Detail { get; set; }
        public List<Department_Model> Department_Detail_List { get; set; }
    }
    public class Designation_Model_Return
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public Designation_Model Designation_Detail { get; set; }
        public List<Designation_Model> Designation_Detail_List { get; set; }
    }

    public class Employee_Return
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public Employee_Model Employee_Detail { get; set; }
        public List<Employee_Model> Employee_Detail_List { get; set; }
    }


}