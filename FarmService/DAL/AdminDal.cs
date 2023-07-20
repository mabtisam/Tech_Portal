using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TechnicalService.Models;
using static TechnicalService.DAL.SQLHelper;
namespace TechnicalService.DAL
{
    public class AdminDAL
    {

        private string _ConnString;

        public AdminDAL()
        {
            _ConnString = ConfigurationManager.ConnectionStrings["TechDB"].ConnectionString;
        }

        public string GetConnectionString()
        {
            return _ConnString;
        }
        //Departemnt DAL
       

        public Department_Model_Return DepartmentList(Department_Model getModel)
        {
            Department_Model_Return RObj = new Department_Model_Return();
            string retstatus, retmessage;
            try
            {
                var parm = new SqlParameter[3];

                parm[0] = new SqlParameter("@Operation", SqlDbType.Int) { Value = getModel.Coperation };
                parm[1] = new SqlParameter("@Department_Id", SqlDbType.Int) { Value = getModel.Department_Id };
                parm[2] = new SqlParameter("@Department_Name", SqlDbType.VarChar) { Value = getModel.Department_Name };

                var dsuser = SqlHelper.ExecuteTable(_ConnString, CommandType.StoredProcedure, "[Usp_Department]", parm);

                var userObj = new Department_Model();
                List<Department_Model> UserLst = new List<Department_Model>();

                retstatus = "2";
                retmessage = "Data Found!";

                foreach (DataRow row in dsuser.Rows)
                {


                    if (retstatus == "2")
                    {
                        userObj = new Department_Model();
                        userObj.Department_Id = Common.CheckIntegerNull(row["Department_Id"]);
                        userObj.Department_Name = Common.CheckStringNull(row["Department_Name"]);
                        
                        UserLst.Add(userObj);
                    }
                }

                RObj.Status = retstatus;
                RObj.Message = retmessage;
                RObj.Department_Detail_List = UserLst;

                return RObj;
            }
            catch (Exception ex)
            {
                RObj.Status = "5";
                RObj.Message = "Error Found, " + ex.ToString();
                return RObj;
            }

        }
        public Department_Model_Return GetDepartmentByID(Department_Model getModel)
        {
            Department_Model_Return RObj = new Department_Model_Return();
            string retstatus, retmessage;
            try
            {
                var parm = new SqlParameter[3];

                parm[0] = new SqlParameter("@Operation", SqlDbType.Int) { Value = 5 };
                parm[1] = new SqlParameter("@Department_Id", SqlDbType.Int) { Value = getModel.Department_Id };
                parm[2] = new SqlParameter("@Department_Name", SqlDbType.VarChar) { Value = getModel.Department_Name };

                var datas = SqlHelper.ExecuteTable(_ConnString, CommandType.StoredProcedure, "[Usp_Department]", parm);
                var userObj = new Department_Model();

                retstatus = "2";
                retmessage = "Data Found!";

                foreach (DataRow row in datas.Rows)
                {

                    if (retstatus == "2")
                    {
                        userObj = new Department_Model();
                        userObj.Department_Id = Common.CheckIntegerNull(row["Department_Id"]);
                        userObj.Department_Name = Common.CheckStringNull(row["Department_Name"]);
                    }
                }


                RObj.Status = retstatus;
                RObj.Message = retmessage;
                RObj.Department_Detail = userObj;

                return RObj;
            }
            catch (Exception ex)
            {
            }
            return null;
        }
        public Department_Model_Return AUDDepartment(Department_Model getModel)
        {
            Department_Model_Return RObj = new Department_Model_Return();
            
            try
            {
                var parm = new SqlParameter[3];

                parm[0] = new SqlParameter("@Operation", SqlDbType.Int) { Value = getModel.Coperation };
                parm[1] = new SqlParameter("@Department_Id", SqlDbType.Int) { Value = getModel.Department_Id };
                parm[2] = new SqlParameter("@Department_Name", SqlDbType.VarChar) { Value = getModel.Department_Name };
               
                var dsuser = SqlHelper.ExecuteTable(_ConnString, CommandType.StoredProcedure, "[Usp_Department]", parm);
                return RObj;
            }
            catch (Exception ex)
            {
                RObj.Status = "5";
                RObj.Message = "Error Found, " + ex.ToString();
                return RObj;
            }
        }
        //Designation DAL
        public Designation_Model_Return DesignationList(Designation_Model getModel)
        {
            Designation_Model_Return RObj = new Designation_Model_Return();
            string retstatus, retmessage;
            try
            {
                var parm = new SqlParameter[3];

                parm[0] = new SqlParameter("@Operation", SqlDbType.Int) { Value = getModel.Coperation };
                parm[1] = new SqlParameter("@Designation_Id", SqlDbType.Int) { Value = getModel.Designation_Id };
                parm[2] = new SqlParameter("@Designation_Name", SqlDbType.VarChar) { Value = getModel.Designation_Name };

                var dsuser = SqlHelper.ExecuteTable(_ConnString, CommandType.StoredProcedure, "[Usp_Designation]", parm);

                var userObj = new Designation_Model();
                List<Designation_Model> UserLst = new List<Designation_Model>();

                retstatus = "2";
                retmessage = "Data Found!";

                foreach (DataRow row in dsuser.Rows)
                {
                    if (retstatus == "2")
                    {
                        userObj = new Designation_Model();
                        userObj.Designation_Id = Common.CheckIntegerNull(row["Designation_Id"]);
                        userObj.Designation_Name = Common.CheckStringNull(row["Designation_Name"]);

                        UserLst.Add(userObj);
                    }
                }

                RObj.Status = retstatus;
                RObj.Message = retmessage;
                RObj.Designation_Detail_List = UserLst;

                return RObj;
            }
            catch (Exception ex)
            {
                RObj.Status = "5";
                RObj.Message = "Error Found, " + ex.ToString();
                return RObj;
            }

        }
        public Designation_Model_Return GetDesignationByID(Designation_Model getModel)
        {
            Designation_Model_Return RObj = new Designation_Model_Return();
            string retstatus, retmessage;
            try
            {
                var parm = new SqlParameter[3];

                parm[0] = new SqlParameter("@Operation", SqlDbType.Int) { Value = 5 };
                parm[1] = new SqlParameter("@Designation_Id", SqlDbType.Int) { Value = getModel.Designation_Id };
                parm[2] = new SqlParameter("@Designation_Name", SqlDbType.VarChar) { Value = getModel.Designation_Name };
                var datas = SqlHelper.ExecuteTable(_ConnString, CommandType.StoredProcedure, "[Usp_Designation]", parm);
                var userObj = new Designation_Model();

                retstatus = "2";
                retmessage = "Data Found!";

                foreach (DataRow row in datas.Rows)
                {

                    if (retstatus == "2")
                    {
                        userObj = new Designation_Model();
                        userObj.Designation_Id = Common.CheckIntegerNull(row["Designation_Id"]);
                        userObj.Designation_Name = Common.CheckStringNull(row["Designation_Name"]);
                    }
                }


                RObj.Status = retstatus;
                RObj.Message = retmessage;
                RObj.Designation_Detail = userObj;

                return RObj;
            }
            catch (Exception ex)
            {
            }
            return null;
        }
        public Designation_Model_Return AUDDesignation(Designation_Model getModel)
        {
            Designation_Model_Return RObj = new Designation_Model_Return();
          
            try
            {
                var parm = new SqlParameter[3];

                parm[0] = new SqlParameter("@Operation", SqlDbType.Int) { Value = getModel.Coperation };
                parm[1] = new SqlParameter("@Designation_Id", SqlDbType.Int) { Value = getModel.Designation_Id };
                parm[2] = new SqlParameter("@Designation_Name", SqlDbType.VarChar) { Value = getModel.Designation_Name };

                var dsuser = SqlHelper.ExecuteTable(_ConnString, CommandType.StoredProcedure, "[Usp_Designation]", parm);
                return RObj;
            }
            catch (Exception ex)
            {
                RObj.Status = "5";
                RObj.Message = "Error Found, " + ex.ToString();
                return RObj;
            }
        }

        public Employee_Return EmployeeList(Employee_Model getModel)
        {
            Employee_Return RObj = new Employee_Return();
            string retstatus, retmessage;
            try
            {
                var parm = new SqlParameter[9];

                parm[0] = new SqlParameter("@Operation", SqlDbType.Int) { Value = getModel.Coperation };
                parm[1] = new SqlParameter("@Employee_Id", SqlDbType.Int) { Value = getModel.Employee_Id };
                parm[2] = new SqlParameter("@Employee_Name", SqlDbType.VarChar) { Value = getModel.Employee_Name };
                parm[3] = new SqlParameter("@Employee_Pic", SqlDbType.VarChar) { Value = getModel.Employee_Pic };
                parm[4] = new SqlParameter("@Department_Id", SqlDbType.Int) { Value = getModel.Department_Id };
                parm[5] = new SqlParameter("@Designation_Id", SqlDbType.Int) { Value = getModel.Designation_Id };
                parm[6] = new SqlParameter("@Employee_Salary", SqlDbType.Int) { Value = getModel.Employee_Salary };
                parm[7] = new SqlParameter("@CNIC", SqlDbType.VarChar) { Value = getModel.CNIC };
                parm[8] = new SqlParameter("@Is_Active", SqlDbType.VarChar) { Value = getModel.Is_Active };

                var dsuser = SqlHelper.ExecuteTable(_ConnString, CommandType.StoredProcedure, "[Usp_Employee]", parm);

                var userObj = new Employee_Model();
                List<Employee_Model> UserLst = new List<Employee_Model>();

                retstatus = "2";
                retmessage = "Data Found!";

                foreach (DataRow row in dsuser.Rows)
                {

                    

                    if (retstatus == "2")
                    {
                        userObj = new Employee_Model();
                        userObj.Employee_Id = Common.CheckIntegerNull(row["Employee_Id"]);
                        userObj.Employee_Name = Common.CheckStringNull(row["Employee_Name"]);
                        userObj.Employee_Pic = Common.CheckStringNull(row["Employee_Pic"]);
                        userObj.Designation_Id = Common.CheckIntegerNull(row["Designation_Id"]);
                        userObj.Department_Id = Common.CheckIntegerNull(row["Department_Id"]);
                        userObj.Employee_Salary = Common.CheckIntegerNull(row["Employee_Salary"]);
                        userObj.CNIC = Common.CheckStringNull(row["CNIC"]);
                        userObj.Is_Active = Common.CheckIntegerNull(row["Is_Active"]);

                        UserLst.Add(userObj);
                    }
                }

                RObj.Status = retstatus;
                RObj.Message = retmessage;
                RObj.Employee_Detail_List = UserLst;

                return RObj;
            }
            catch (Exception ex)
            {
                RObj.Status = "5";
                RObj.Message = "Error Found, " + ex.ToString();
                return RObj;
            }

        }
        public Employee_Return GetEmployeeByID(Employee_Model getModel)
        {
            Employee_Return RObj = new Employee_Return();
            string retstatus, retmessage;
            try
            {
                var parm = new SqlParameter[9];

                parm[0] = new SqlParameter("@Operation", SqlDbType.Int) { Value = getModel.Coperation };
                parm[1] = new SqlParameter("@Employee_Id", SqlDbType.Int) { Value = getModel.Employee_Id };
                parm[2] = new SqlParameter("@Employee_Name", SqlDbType.VarChar) { Value = getModel.Employee_Name };
                parm[3] = new SqlParameter("@Employee_Pic", SqlDbType.VarChar) { Value = getModel.Employee_Pic };
                parm[4] = new SqlParameter("@Department_Id", SqlDbType.Int) { Value = getModel.Department_Id };
                parm[5] = new SqlParameter("@Designation_Id", SqlDbType.Int) { Value = getModel.Designation_Id };
                parm[6] = new SqlParameter("@Employee_Salary", SqlDbType.Int) { Value = getModel.Employee_Salary };
                parm[7] = new SqlParameter("@CNIC", SqlDbType.VarChar) { Value = getModel.CNIC };
                parm[8] = new SqlParameter("@Is_Active", SqlDbType.VarChar) { Value = getModel.Is_Active };

                var datas = SqlHelper.ExecuteTable(_ConnString, CommandType.StoredProcedure, "[Usp_Designation]", parm);
                var userObj = new Employee_Model();

                retstatus = "2";
                retmessage = "Data Found!";

                foreach (DataRow row in datas.Rows)
                {
                   

                    if (retstatus == "2")
                    {
                        userObj = new Employee_Model();
                        userObj.Employee_Id = Common.CheckIntegerNull(row["Employee_Id"]);
                        userObj.Employee_Name = Common.CheckStringNull(row["Employee_Name"]);
                        userObj.Employee_Pic = Common.CheckStringNull(row["Employee_Pic"]);
                        userObj.Designation_Id = Common.CheckIntegerNull(row["Designation_Id"]);
                        userObj.Department_Id = Common.CheckIntegerNull(row["Department_Id"]);
                        userObj.Employee_Salary = Common.CheckIntegerNull(row["Employee_Salary"]);
                        userObj.CNIC = Common.CheckStringNull(row["CNIC"]);
                        userObj.Is_Active = Common.CheckIntegerNull(row["Designation_Name"]);

                    }
                }


                RObj.Status = retstatus;
                RObj.Message = retmessage;
                RObj.Employee_Detail = userObj;

                return RObj;
            }
            catch (Exception ex)
            {
            }
            return null;
        }
        public Employee_Return AUDEmployee(Employee_Model getModel)
        {
            Employee_Return RObj = new Employee_Return();
           
            try
            {
                var parm = new SqlParameter[9];

                parm[0] = new SqlParameter("@Operation", SqlDbType.Int) { Value = getModel.Coperation };
                parm[1] = new SqlParameter("@Employee_Id", SqlDbType.Int) { Value = getModel.Employee_Id };
                parm[2] = new SqlParameter("@Employee_Name", SqlDbType.VarChar) { Value = getModel.Employee_Name };
                parm[3] = new SqlParameter("@Employee_Pic", SqlDbType.VarChar) { Value = getModel.Employee_Pic };
                parm[4] = new SqlParameter("@Department_Id", SqlDbType.Int) { Value = getModel.Department_Id };
                parm[5] = new SqlParameter("@Designation_Id", SqlDbType.Int) { Value = getModel.Designation_Id };
                parm[6] = new SqlParameter("@Employee_Salary", SqlDbType.Int) { Value = getModel.Employee_Salary };
                parm[7] = new SqlParameter("@CNIC", SqlDbType.VarChar) { Value = getModel.CNIC };
                parm[8] = new SqlParameter("@Is_Active", SqlDbType.VarChar) { Value = getModel.Is_Active };

                var dsuser = SqlHelper.ExecuteTable(_ConnString, CommandType.StoredProcedure, "[Usp_Employee]", parm);
                return RObj;
            }
            catch (Exception ex)
            {
                RObj.Status = "5";
                RObj.Message = "Error Found, " + ex.ToString();
                return RObj;
            }
        }

    }
}