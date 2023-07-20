using System;
using System.Collections.Generic;
using System.Configuration;
using TechnicalPortal.Configuration;
using System.Linq;
using System.Web;
using RestSharp;

namespace TechnicalPortal.Network_Manager
{
    public class TechWebClient
    {

        static string _url = ConfigurationManager.AppSettings["ApiBaseUrl"];
        static RestClient _instance = new RestClient(AppSettings.ApiBaseUrl);
        private TechWebClient()
        {


        }

        public static RestClient Instance => _instance;
    }
}