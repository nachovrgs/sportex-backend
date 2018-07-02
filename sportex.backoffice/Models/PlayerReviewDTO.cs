using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sportex.backoffice.Models
{
    public class PlayerReviewDTO
    {
        #region PROPERTIES
        public int Rate { get; set; }
        public string Message { get; set; }
        public int IdProfileReviews { get; set; }
        public StandardProfileDTO ProfileReviews { get; set; }
        public int IdProfileReviewed { get; set; }
        public StandardProfileDTO ProfileReviewed { get; set; }
        public int EventID { get; set; }
        public EventDTO EventReviewed { get; set; }
        #endregion

        public PlayerReviewDTO()
        {
            try
            {
                this.Rate = 0;
                this.Message = "";
                this.IdProfileReviews = 0;
                this.IdProfileReviewed = 0;
                this.ProfileReviews = null;
                this.ProfileReviewed = null;
                this.EventID = 0;
                this.EventReviewed = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}