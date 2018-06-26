using sportex.backoffice.Configuration.Auth;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace sportex.backoffice.Configuration
{
    public static class GlobalVariables
    {
        private static string apiUrl = null;
        private static HttpClient apiClient = null;

        public static string ApiUrl()
        {
            try
            {
                if(apiUrl == null)
                {
                    apiUrl = ConfigurationManager.AppSettings["ApiUrl"];
                }
                return apiUrl;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static HttpClient ApiClient()
        {
            try
            {
                //if (apiClient == null)
                //{
                    apiClient = new HttpClient();
                    //Passing service base url  
                    apiClient.BaseAddress = new Uri(GlobalVariables.ApiUrl());

                    apiClient.DefaultRequestHeaders.Clear();

                    //Define request data format  
                    apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    apiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthManager.Token());
               // }
                return apiClient;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}