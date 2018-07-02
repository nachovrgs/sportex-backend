using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sportex.backoffice.Models
{
    public class GroupMemberDTO
    {
        #region PROPERTIES
        public int StandardProfileID { get; set; }
        public StandardProfileDTO ProfileMember { get; set; }
        public int GroupID { get; set; }
        //public GroupDTO GroupIntegrates { get; set; }
        public int Type { get; set; }
        #endregion

        public GroupMemberDTO()
        {
            try
            {
                this.StandardProfileID = 0;
                this.ProfileMember = null;
                this.GroupID = 0;
                this.Type = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}