using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace TechnicalPortal.Configuration
{
    public class AppSettings
    {
        public static string ApiBaseUrl => ConfigurationManager.AppSettings["ApiBaseUrl"];
    }
}