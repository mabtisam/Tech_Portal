using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechnicalPortal.Network_Manager;
using TechnicalService.Models;

namespace TechnicalPortal.Controllers
{
    public class ListController : Controller
    {
        public ActionResult DesignationList()
        {
            try
            {
                Designation_Model PostModel = new Designation_Model();
                PostModel.Coperation = 1;
                var objReturn = AdminRequest.DesignationList(PostModel);
                List<Designation_Model> getmodel = objReturn.Designation_Detail_List;
                return Json(getmodel, JsonRequestBehavior.AllowGet);
            }

            catch (Exception ex)
            {
                throw;
            }

        } public ActionResult DepartmentList()
        {
            try
            {
                Department_Model PostModel = new Department_Model();
                PostModel.Coperation = 1;
                var objReturn = AdminRequest.DepartmentList();
                List<Department_Model> getmodel = objReturn.Department_Detail_List;
                return Json(getmodel, JsonRequestBehavior.AllowGet);
            }

            catch (Exception ex)
            {
                throw;
            }

        }
    }
}