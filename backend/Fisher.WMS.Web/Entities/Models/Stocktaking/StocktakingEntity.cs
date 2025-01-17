/*
 * date：2022-12-30
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
    /// stocktaking  entity
    /// </summary>
    [Table("stocktaking")]
    public class StocktakingEntity : BaseModel
    {

        #region Property

        /// <summary>
        /// job_code
        /// </summary>
        public string job_code { get; set; }  = string.Empty;

        /// <summary>
        /// job_status
        /// </summary>
        public bool job_status { get; set; } = false;

        /// <summary>
        /// sku_id
        /// </summary>
        public int sku_id { get; set; }  = 0;

        /// <summary>
        /// goods_owner_id
        /// </summary>
        public int goods_owner_id { get; set; }  = 0;

        /// <summary>
        /// goods_location_id
        /// </summary>
        public int goods_location_id { get; set; }  = 0;

        /// <summary>
        /// book_qty
        /// </summary>
        public int book_qty { get; set; }  = 0;

        /// <summary>
        /// counted_qty
        /// </summary>
        public int counted_qty { get; set; }  = 0;

        /// <summary>
        /// difference_qty
        /// </summary>
        public int difference_qty { get; set; }  = 0;

        /// <summary>
        /// creator
        /// </summary>
        public string creator { get; set; }  = string.Empty;

        /// <summary>
        /// create_time
        /// </summary>
        public DateTime create_time { get; set; }  = DateTime.Now;

        /// <summary>
        /// last_update_time
        /// </summary>
        public DateTime last_update_time { get; set; }  = DateTime.Now;

        /// <summary>
        /// tenant_id
        /// </summary>
        public long tenant_id { get; set; }  = 1;

        /// <summary>
        /// handler
        /// </summary>
        public string handler { get; set; } = string.Empty;

        /// <summary>
        /// handle_time
        /// </summary>
        public DateTime handle_time { get; set; } = UtilConvert.MinDate;

        #endregion

    }
}
