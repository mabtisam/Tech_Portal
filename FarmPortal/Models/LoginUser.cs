using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnicalPortal.Models
{
    public class LoginUser
    {

        public int Coperation { get; set; }
        public string Client_Code { get; set; }
        public string Client_Name { get; set; }
        public string Company_Code { get; set; }
        public string Company_Name { get; set; }
        public string UM_User_Id { get; set; }
        public string UM_User_Password { get; set; }
        public string UM_User_First_Name { get; set; }
        public string UM_User_Last_Name { get; set; }
        public string UM_User_Email { get; set; }
        public string UM_User_Contact_Number { get; set; }
        public int UM_User_IsAdmin { get; set; }
        public int UM_User_IsActive { get; set; }
        public int UM_Role_Code { get; set; }
        public string UM_Role_Name { get; set; }
        public int Designation_Code { get; set; }
        public string Designation_Name { get; set; }
        public int Department_Code { get; set; }
        public string Department_Name { get; set; }
        public string Employee_Code { get; set; }
        public string Created_By { get; set; }
        public DateTime? Created_Date_Time { get; set; }
        public string Edited_By { get; set; }
        public DateTime? Edited_Date_Time { get; set; }
        public string Message_Code { get; set; }
        public string Message_Title { get; set; }
    }

    public class LogInUserHelper
    {
        public LoginUser GetLoggedInUser()
        {
            return JsonConvert.DeserializeObject<LoginUser>(HttpContext.Current.User.Identity.Name);
        }
        public static LoginUser GetLoggedInUserRazor()
        {
            return JsonConvert.DeserializeObject<LoginUser>(HttpContext.Current.User.Identity.Name);
        }
    }

}