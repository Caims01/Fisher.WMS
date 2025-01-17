/*
 * date：2022-12-23
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
    /// stockprocessdetail  entity
    /// </summary>
    [Table("stockprocessdetail")]
    public class StockprocessdetailEntity : BaseModel
    {
        #region  foreign table

         /// <summary>
         /// foreign table
         /// </summary>
        [ForeignKey("stock_process_id")]
         public StockprocessEntity Stockprocess { get; set; }

        #endregion

        #region Property

        /// <summary>
        /// stock_process_id
        /// </summary>
        public int stock_process_id { get; set; }  = 0;

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
        /// qty
        /// </summary>
        public int qty { get; set; }  = 0;

        /// <summary>
        /// last_update_time
        /// </summary>
        public DateTime last_update_time { get; set; }  = UtilConvert.MinDate;

        /// <summary>
        /// tenant_id
        /// </summary>
        public long tenant_id { get; set; }  = 0;

        /// <summary>
        /// is_source
        /// </summary>
        public bool is_source { get; set; } = false;

        /// <summary>
        /// is_update_stock
        /// </summary>
        public bool is_update_stock { get; set; } = false;
        #endregion

    }
}
