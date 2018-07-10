using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sportex.backoffice.Models
{
    public class LocationDTO
    {
        #region PROPERTIES
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        #endregion

        public LocationDTO()
        {
            try
            {
                this.ID = 0;
                this.Name = "";
                this.Description = "";
                this.Latitude = null;
                this.Longitude = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}