using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sportex.backoffice.Models
{
    public class EventParticipantDTO
    {
        #region PROPERTIES
        public int StandardProfileID { get; set; }
        public StandardProfileDTO ProfileParticipant { get; set; }
        public int EventID { get; set; }
        public int Type { get; set; }
        public int Order { get; set; }
        #endregion

        public EventParticipantDTO()
        {
            try
            {
                this.StandardProfileID = 0;
                this.ProfileParticipant = null;
                this.EventID = 0;
                this.Type = 0;
                this.Order = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}