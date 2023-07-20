using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechnicalPortal.Models;
using TechnicalService.Models;

namespace TechnicalPortal.Network_Manager
{
    public class AdminRequest
    {
        public static string GetConnectionString()
        {
            var request = new RestRequest("api/Admin/GetConnectionString", Method.GET) { RequestFormat = DataFormat.Json };
            var restResponse = TechWebClient.Instance.Execute(request);
            var response = restResponse.Content;

            return JsonConvert.DeserializeObject<string>(response);
        }

        //Department Request
        public static Department_Model_Return DepartmentList()
        {
            Department_Model getModel = new Department_Model();

            getModel.Coperation = 1;
            var url = $"api/Admin/DepartmentList";
            var request = new RestRequest(url, Method.POST) { RequestFormat = DataFormat.Json };
            request.AddJsonBody(getModel);
            var restResponse = TechWebClient.Instance.Execute(request);
            var response = restResponse.Content;

            return JsonConvert.DeserializeObject<Department_Model_Return>(response);

        }
        public static Department_Model_Return AUDDepartment(Department_Model PostModel)
        {


            var request = new RestRequest("api/Admin/AUDDepartment", Method.POST) { RequestFormat = DataFormat.Json };
            request.AddJsonBody(PostModel);
            var restResponse = TechWebClient.Instance.Execute(request);
            var response = restResponse.Content;
            return JsonConvert.DeserializeObject<Department_Model_Return>(response);
        }
        public static Department_Model_Return GetDepartmentByID(Department_Model getModel)
        {
            var request = new RestRequest("api/Admin/GetDepartmentByID", Method.POST) { RequestFormat = DataFormat.Json };
            request.AddJsonBody(getModel);
            var restResponse = TechWebClient.Instance.Execute(request);
            var response = restResponse.Content;
            return JsonConvert.DeserializeObject<Department_Model_Return>(response);
        }


        public static Designation_Model_Return DesignationList(Designation_Model getModel)
        {
            getModel.Coperation = 1;
            var request = new RestRequest("api/Admin/DesignationList", Method.POST) { RequestFormat = DataFormat.Json };
            request.AddJsonBody(getModel);
            var restResponse = TechWebClient.Instance.Execute(request);
            var response = restResponse.Content;
            return JsonConvert.DeserializeObject<Designation_Model_Return>(response);
        }

        public static Designation_Model_Return GetDesignationByID(Designation_Model getModel)
        {

            var request = new RestRequest("api/Admin/GetDesignationByID", Method.POST) { RequestFormat = DataFormat.Json };
            request.AddJsonBody(getModel);
            var restResponse = TechWebClient.Instance.Execute(request);
            var response = restResponse.Content;
            return JsonConvert.DeserializeObject<Designation_Model_Return>(response);
        }
        public static Designation_Model_Return AUDDesignation(Designation_Model PostModel)
        {
            var request = new RestRequest("api/Admin/AUDDesignation", Method.POST) { RequestFormat = DataFormat.Json };
            request.AddJsonBody(PostModel);
            var restResponse = TechWebClient.Instance.Execute(request);
            var response = restResponse.Content;
            return JsonConvert.DeserializeObject<Designation_Model_Return>(response);
        }


        //Designation Request

       


        //Employee Request
        public static Employee_Return EmployeeList()
        {
            Employee_Model getModel = new Employee_Model();
            getModel.Coperation = 1;
            var url = $"api/Admin/EmployeeList";
            var request = new RestRequest(url, Method.POST) { RequestFormat = DataFormat.Json };
            request.AddJsonBody(getModel);
            var restResponse = TechWebClient.Instance.Execute(request);
            var response = restResponse.Content;

            return JsonConvert.DeserializeObject<Employee_Return>(response);

        }
        public static Employee_Return AUDEmployee(Employee_Model PostModel)
        {


            var request = new RestRequest("api/Admin/AUDEmployee", Method.POST) { RequestFormat = DataFormat.Json };
            request.AddJsonBody(PostModel);
            var restResponse = TechWebClient.Instance.Execute(request);
            var response = restResponse.Content;
            return JsonConvert.DeserializeObject<Employee_Return>(response);
        }
        public static Employee_Return GetEmployeeByID(Employee_Model getModel)
        {
            var request = new RestRequest("api/Admin/GetEmployeeByID", Method.POST) { RequestFormat = DataFormat.Json };
            request.AddJsonBody(getModel);
            var restResponse = TechWebClient.Instance.Execute(request);
            var response = restResponse.Content;
            return JsonConvert.DeserializeObject<Employee_Return>(response);
        }
       
    }
}