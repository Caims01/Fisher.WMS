﻿using Fisher.WMS.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fisher.WMS.Web.Entities.Models
{
    /// <summary>
    /// goods owner entity
    /// </summary>
    [Table("goodsowner")]
    public class GoodsownerEntity : BaseModel
    {
        #region Property
        /// <summary>
        /// goods owner name
        /// </summary>
        public string goods_owner_name { get; set; } = string.Empty;

        /// <summary>
        /// city
        /// </summary>
        public string city { get; set; } = string.Empty;

        /// <summary>
        /// address
        /// </summary>
        public string address { get; set; } = string.Empty;

        /// <summary>
        /// manager
        /// </summary>
        public string manager { get; set; } = string.Empty;

        /// <summary>
        /// contact tel
        /// </summary>
        public string contact_tel { get; set; } = string.Empty;

        /// <summary>
        /// creator
        /// </summary>
        public string creator { get; set; } = string.Empty;

        /// <summary>
        /// create time
        /// </summary>
        public DateTime create_time { get; set; } = DateTime.Now;

        /// <summary>
        /// last update time
        /// </summary>
        public DateTime last_update_time { get; set; } = DateTime.Now;

        /// <summary>
        /// valid
        /// </summary>
        public bool is_valid { get; set; } = true;

        /// <summary>
        /// the tenant id
        /// </summary>
        public long tenant_id { get; set; } = 1;
        #endregion
    }
}
