using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace sportex.backoffice.Configuration.Auth
{
    public static class AuthManager
    {
        private static string token;
        private static string apiUrl = GlobalVariables.ApiUrl();
        private static TokenRequest tokenRequest = new TokenRequest(ConfigurationManager.AppSettings["Username"], ConfigurationManager.AppSettings["Password"]);

        public static string Token()
        {
            try
            {
                if (token == null || token == "")
                {
                    GetToken();
                }
                return token;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        //Obtiene un nuevo Token
        public static async void GetToken()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage res = await client.PostAsJsonAsync("/api/Auth", tokenRequest);

                    if (res.IsSuccessStatusCode)
                    { 
                        var profResponse = res.Content.ReadAsStringAsync().Result;
                        TokenResponse jsonToken = JsonConvert.DeserializeObject<TokenResponse>(profResponse);
                        token = jsonToken.Token;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}