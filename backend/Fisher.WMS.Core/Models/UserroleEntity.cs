/*
 * date：2022-12-20
 * developer：NoNo
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Fisher.WMS.Core.Models;
using Fisher.WMS.Core.Utility;

namespace Fisher.WMS.Core.Models
{
    /// <summary>
    /// userrole  entity
    /// </summary>
    [Table("userrole")]
    public class UserroleEntity : BaseModel
    {

        #region Property

        /// <summary>
        /// role_name
        /// </summary>
        public string role_name { get; set; }  = string.Empty;

        /// <summary>
        /// is_valid
        /// </summary>
        public bool is_valid { get; set; } = false;

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
        public long tenant_id { get; set; }  = 0;


        #endregion

    }
}
