using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sportex.backoffice.Configuration.Auth
{
    public class TokenRequest
    {
        #region PROPERTIES
        public string Username { get; set; }
        public string Password { get; set; }
        #endregion

        public TokenRequest()
        {
            try
            {
                this.Username = "";
                this.Password = "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TokenRequest(string name, string pass)
        {
            try
            {
                this.Username = name;
                this.Password = pass;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}