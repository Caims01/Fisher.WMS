/*
 * date：2022-12-20
 * developer：AMo
 */
using System.ComponentModel.DataAnnotations;

namespace Fisher.WMS.Web.Entities.ViewModels
{
    /// <summary>
    /// rolemenu viewModel
    /// </summary>
    public class RolemenuViewModel
    {

        #region constructor
        /// <summary>
        /// constructor
        /// </summary>
        public RolemenuViewModel()
        {

        }
        #endregion

        #region Property

        /// <summary>
        /// id
        /// </summary>
        [Display(Name = "id")]
        public int id { get; set; } = 0;
         
        /// <summary>
        /// menu_id
        /// </summary>
        [Display(Name = "menu_id")]
        public int menu_id { get; set; } = 0;

        /// <summary>
        /// menu_name
        /// </summary>
        [Display(Name = "menu_name")]
        [MaxLength(32, ErrorMessage = "MaxLength")]
        public string menu_name { get; set; } = string.Empty;

        /// <summary>
        /// authority
        /// </summary>
        [Display(Name = "authority")]
        public byte authority { get; set; } = 1;

        #endregion

    }
}
