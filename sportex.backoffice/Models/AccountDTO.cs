using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sportex.backoffice.Models
{
    public class AccountDTO
    {
        #region PROPERTIES
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        #endregion

        public AccountDTO()
        {
            try
            {
                this.ID = 0;
                this.Username = "";
                this.Password = "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}