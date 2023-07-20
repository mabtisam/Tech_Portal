using TechnicalService.DAL;
using TechnicalService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace TechnicalService.Controllers
{
    public class AdminController : ApiController
    {

        AdminDAL _bal = new AdminDAL();

        [HttpGet]
        [Route("api/Admin/GetConnectionString")]
        public string GetConnectionString()
        {
            var conStr = _bal.GetConnectionString();
            return conStr;
        }

        //Department api controller
        [HttpPost]
        [Route("api/Admin/DepartmentList")]
        public Department_Model_Return DepartmentList(Department_Model getModel)
        {
            var userList = _bal.DepartmentList(getModel);
            return userList;
        }

        [HttpPost, Route("api/Admin/AUDDepartment")]
        public Department_Model_Return AUDDepartment(Department_Model getModel)
        {
            var userList = _bal.AUDDepartment(getModel);
            return userList;
        }
        [HttpPost]
        [Route("api/Admin/GetDepartmentByID")]
        public Department_Model_Return GetDepartmentByID(Department_Model getModel)
        {
            var userList = _bal.GetDepartmentByID(getModel);
            return userList;
        }


        //Designation api controller
        [HttpPost]
        [Route("api/Admin/DesignationList")]
        public Designation_Model_Return DesignationList(Designation_Model getModel)
        {
            var userList = _bal.DesignationList(getModel);
            return userList;
        }

        [HttpPost, Route("api/Admin/AUDDesignation")]
        public Designation_Model_Return AUDDesignation(Designation_Model getModel)
        {
            var userList = _bal.AUDDesignation(getModel);
            return userList;
        }


        [HttpPost]
        [Route("api/Admin/GetDesignationByID")]
        public Designation_Model_Return GetDesignationByID(Designation_Model getModel)
        {
            var userList = _bal.GetDesignationByID(getModel);
            return userList;
        }

        //Designation api controller
        [HttpPost]
        [Route("api/Admin/EmployeeList")]
        public Employee_Return EmployeeList(Employee_Model getModel)
        {
            var userList = _bal.EmployeeList(getModel);
            return userList;
        }

        [HttpPost, Route("api/Admin/AUDEmployee")]
        public Employee_Return AUDEmployee(Employee_Model getModel)
        {
            var userList = _bal.AUDEmployee(getModel);
            return userList;
        }


        [HttpPost]
        [Route("api/Admin/GetEmployeeByID")]
        public Employee_Return GetEmployeeByID(Employee_Model getModel)
        {
            var userList = _bal.GetEmployeeByID(getModel);
            return userList;
        }

    }
}
