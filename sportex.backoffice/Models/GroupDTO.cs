using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sportex.backoffice.Models
{
    public class GroupDTO
    {
        #region PROPERTIES
        public int ID { get; set; }
        public int StandardProfileID { get; set; }
        public StandardProfileDTO CreatorProfile { get; set; }
        public string GroupName { get; set; }
        public string GroupDescription { get; set; }
        public string PicturePath { get; set; }
        public int MemberCount { get; set; }
        public List<GroupMemberDTO> ListMembers { get; set; }

        #endregion

        public GroupDTO()
        {
            try
            {
                this.StandardProfileID = 0;
                this.CreatorProfile = null;
                this.GroupName = "";
                this.GroupDescription = "";
                this.PicturePath = "";
                this.MemberCount = 0;
                this.ListMembers = new List<GroupMemberDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}