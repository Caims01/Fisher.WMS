/*
 * date：2022-12-20
 * developer：AMo
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Fisher.WMS.Core.Models;
using Fisher.WMS.Core.Utility;

namespace Fisher.WMS.Web.Entities.Models
{
    /// <summary>
    /// rolemenu  entity
    /// </summary>
    [Table("rolemenu")]
    public class RolemenuEntity : BaseModel
    {

        #region Property

        /// <summary>
        /// userrole_id
        /// </summary>
        public int userrole_id { get; set; }  = 0;

        /// <summary>
        /// menu_id
        /// </summary>
        public int menu_id { get; set; }  = 0;

        /// <summary>
        /// authority
        /// </summary>
        public byte authority { get; set; }  = 1;

        /// <summary>
        /// create_time
        /// </summary>
        public DateTime create_time { get; set; }  = UtilConvert.MinDate;

        /// <summary>
        /// last_update_time
        /// </summary>
        public DateTime last_update_time { get; set; }  = UtilConvert.MinDate;

        /// <summary>
        /// tenant_id
        /// </summary>
        public long tenant_id { get; set; }  = 1;


        #endregion

    }
}
