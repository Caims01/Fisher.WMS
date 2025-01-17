/*
 * date：2022-12-27
 * developer：NoNo
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
    /// stockmove  entity
    /// </summary>
    [Table("stockmove")]
    public class StockmoveEntity : BaseModel
    {

        #region Property

        /// <summary>
        /// job_code
        /// </summary>
        public string job_code { get; set; }  = string.Empty;

        /// <summary>
        /// move_status
        /// </summary>
        public byte move_status { get; set; }  = 0;

        /// <summary>
        /// sku_id
        /// </summary>
        public int sku_id { get; set; }  = 0;

        /// <summary>
        /// orig_goods_location_id
        /// </summary>
        public int orig_goods_location_id { get; set; }  = 0;

        /// <summary>
        /// dest_googs_location_id
        /// </summary>
        public int dest_googs_location_id { get; set; }  = 0;

        /// <summary>
        /// qty
        /// </summary>
        public int qty { get; set; }  = 0;

        /// <summary>
        /// goods_owner_id
        /// </summary>
        public int goods_owner_id { get; set; }  = 0;

        /// <summary>
        /// handler
        /// </summary>
        public string handler { get; set; }  = string.Empty;

        /// <summary>
        /// handle_time
        /// </summary>
        public DateTime handle_time { get; set; }  = UtilConvert.MinDate;

        /// <summary>
        /// creator
        /// </summary>
        public string creator { get; set; }  = string.Empty;

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
