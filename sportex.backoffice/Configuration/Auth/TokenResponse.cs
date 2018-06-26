using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sportex.backoffice.Configuration.Auth
{
    public class TokenResponse
    {
        public string Token { get; set; }
        public string Expires { get; set; }
        public string AccountId { get; set; }

        public TokenResponse()
        {
            try
            {
                this.Token = "";
                this.Expires = "";
                this.AccountId = "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}