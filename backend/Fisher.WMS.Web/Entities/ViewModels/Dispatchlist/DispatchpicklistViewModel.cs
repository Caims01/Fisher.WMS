/*
 * date：2022-12-22
 * developer：NoNo
 */
using System;
using System.ComponentModel.DataAnnotations;
using Fisher.WMS.Core.Utility;

namespace Fisher.WMS.Web.Entities.ViewModels
{
    /// <summary>
    /// dispatchpicklist viewModel
    /// </summary>
    public class DispatchpicklistViewModel
    {

         #region constructor
         /// <summary>
         /// constructor
         /// </summary>
         public DispatchpicklistViewModel()
         {
 
         }
         #endregion
        #region Property

        /// <summary>
        /// id
        /// </summary>
        [Display(Name = "id")]
        public int id { get; set; }  = 0;

        /// <summary>
        /// dispatchlist_id
        /// </summary>
        [Display(Name = "dispatchlist_id")]
        public int dispatchlist_id { get; set; }  = 0;

        /// <summary>
        /// goods_owner_id
        /// </summary>
        [Display(Name = "goods_owner_id")]
        public int goods_owner_id { get; set; }  = 0;

        /// <summary>
        /// goods_location_id
        /// </summary>
        [Display(Name = "goods_location_id")]
        public int goods_location_id { get; set; }  = 0;

        /// <summary>
        /// sku_id
        /// </summary>
        [Display(Name = "sku_id")]
        public int sku_id { get; set; }  = 0;

        /// <summary>
        /// pick_qty
        /// </summary>
        [Display(Name = "pick_qty")]
        public int pick_qty { get; set; }  = 0;

        /// <summary>
        /// picked_qty
        /// </summary>
        [Display(Name = "picked_qty")]
        public int picked_qty { get; set; }  = 0;

        /// <summary>
        /// spu_code
        /// </summary>
        public string spu_code { get; set; } = string.Empty;

        /// <summary>
        /// spu_name
        /// </summary>
        public string spu_name { get; set; } = string.Empty;

        /// <summary>
        /// spu_description
        /// </summary>
        public string spu_description { get; set; } = string.Empty;

        /// <summary>
        /// bar_code
        /// </summary>
        public string bar_code { get; set; } = string.Empty;

        /// <summary>
        /// sku_code
        /// </summary>
        public string sku_code { get; set; } = string.Empty;

        /// <summary>
        /// goods owner name
        /// </summary>
        public string goods_owner_name { get; set; } = string.Empty;

        /// <summary>
        /// warehouse_name
        /// </summary>
        public string warehouse_name { get; set; } = string.Empty;

        /// <summary>
        /// warehouse_area_name
        /// </summary>
        public string warehouse_area_name { get; set; } = string.Empty;

        /// <summary>
        /// warehouse_area_property
        /// </summary>
        public byte warehouse_area_property { get; set; } = 0;

        /// <summary>
        /// location_name
        /// </summary>
        public string location_name { get; set; } = string.Empty;

        #endregion

    }
}
