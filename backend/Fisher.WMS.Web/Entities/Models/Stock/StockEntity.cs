/*
 * date：2022-12-22
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
    /// stock  entity
    /// </summary>
    [Table("stock")]
    public class StockEntity : BaseModel
    {

        #region Property

        /// <summary>
        /// sku_id
        /// </summary>
        public int sku_id { get; set; }  = 0;

        /// <summary>
        /// goods_location_id
        /// </summary>
        public int goods_location_id { get; set; }  = 0;

        /// <summary>
        /// qty
        /// </summary>
        public int qty { get; set; }  = 0;

        /// <summary>
        /// goods_owner_id
        /// </summary>
        public int goods_owner_id { get; set; }  = 0;

        /// <summary>
        /// is_freeze
        /// </summary>
        public bool is_freeze { get; set; } = false;

        /// <summary>
        /// last_update_time
        /// </summary>
        [ConcurrencyCheck]
        public DateTime last_update_time { get; set; }  = UtilConvert.MinDate;

        /// <summary>
        /// tenant_id
        /// </summary>
        public long tenant_id { get; set; }  = 0;


        #endregion

    }
}
