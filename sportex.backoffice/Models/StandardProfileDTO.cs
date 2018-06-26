using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sportex.backoffice.Models
{
    public class StandardProfileDTO : BaseProfileDTO
    {
        #region PROPERTIES
        public DateTime DateOfBirth { get; set; }
        public int Sex { get; set; }
        public double TotalRate { get; set; }
        public double CountReviews { get; set; }
        public double AverageRating { get; set; }


        #endregion

        public StandardProfileDTO()
        {
            try
            {
                this.ID = 0;
                this.AccountID = 0;
                this.Account = null;
                this.MailAddress = "";
                this.FirstName = "";
                this.LastName = "";
                this.PicturePath = "";
                this.DateOfBirth = new DateTime();
                this.Sex = 0;
                this.TotalRate = 0;
                this.CountReviews = 0;
                this.AverageRating = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}