using TechnicalService.Models;
using TechnicalPortal.Network_Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.DynamicData;
using System.IO;
using TechnicalPortal.Models;

namespace TechnicalPortal.Controllers
{
    public class AdminController : Controller
    {



        #region // Department
        //Department

        public ActionResult DepartmentList()
        {
            List<Department_Model> retList = new List<Department_Model>();

            var retModel = AdminRequest.DepartmentList();

            if (retModel.Status == "2")
            {
                retList = retModel.Department_Detail_List;
            }

            return View(retList);

        }

        [HttpPost]
        public ActionResult AUDDepartment(Department_Model getModel)
        {
            var retModel = AdminRequest.AUDDepartment(getModel);

            return RedirectToAction("DepartmentList", "Admin");
        }


        [HttpGet]
        public ActionResult GetDepartmentByID(Department_Model getModel)
        {
            try
            {

                var retModel = AdminRequest.GetDepartmentByID(getModel);
                return Json(retModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region // Designation
        //Designation

        public ActionResult DesignationList(Designation_Model getmodel)
        {
            List<Designation_Model> retList = new List<Designation_Model>();

            var retModel = AdminRequest.DesignationList(getmodel);

            if (retModel.Status == "2")
            {
                retList = retModel.Designation_Detail_List;
            }

            return View(retList);

        }

        [HttpPost]
        public ActionResult AUDDesignation(Designation_Model getModel)
        {
            var retModel = AdminRequest.AUDDesignation(getModel);

            return RedirectToAction("DesignationList", "Admin");
        }


        [HttpGet]
        public ActionResult GetDesignationByID(Designation_Model getModel)
        {
            try
            {

                var retModel = AdminRequest.GetDesignationByID(getModel);
                return Json(retModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region // Employee


        public ActionResult EmployeeList(Employee_Model getModel)

        {
            List<Employee_Model> retList = new List<Employee_Model>();
            if (!string.IsNullOrWhiteSpace(getModel.Employee_Pic))
            {
                string[] imgPath = getModel.Employee_Pic.Split('/');
                getModel.Employee_Pic = imgPath[imgPath.Length - 1];
            }


          

            var retModel = AdminRequest.EmployeeList();

            if (retModel.Status == "2")
            {
                retList = retModel.Employee_Detail_List;
            }

            return View(retList);

        }




        public ActionResult AUDEmployee( HttpPostedFileBase Employee_Pic)
        {

            Employee_Model PostModel = new Employee_Model();
            PostModel.Coperation = Convert.ToInt16(Request["Coperation"]); 
            PostModel.Employee_Id = Convert.ToInt16(Request["Employee_Id"]); 
            PostModel.Employee_Name = Convert.ToString(Request["Employee_Name"]); 
            PostModel.Department_Id = Convert.ToInt32(Request["Department_Id"]); 
            PostModel.Designation_Id = Convert.ToInt32(Request["Designation_Id"]); 
            PostModel.Employee_Salary = Convert.ToDecimal(Request["Employee_Salary"]); 
            PostModel.CNIC = Convert.ToString(Request["CNIC"]); 
            PostModel.Is_Active = Convert.ToInt32(Request["Is_Active"]); 
            var imgpath = string.Empty;
            if (Employee_Pic != null && Employee_Pic.ContentLength > 0)
            {
                var filename = Path.GetFileName(Employee_Pic.FileName);
                imgpath = Path.Combine(Server.MapPath("~/assets/Images/"), filename);
                Employee_Pic.SaveAs(imgpath);
                imgpath = "~/assets/Images/" + imgpath.Split(new[] { "Images\\" }, StringSplitOptions.None)[1];
                PostModel.Employee_Pic = imgpath;

            }


            var returnvar = AdminRequest.AUDEmployee(PostModel);

            return RedirectToAction("EmployeeList", "Admin");



        }


        [HttpGet]
        public ActionResult GetEmployeeByID(Employee_Model getModel)
        {


            try
            {

                var retModel = AdminRequest.GetEmployeeByID(getModel);
                return Json(retModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        #endregion

    }
}