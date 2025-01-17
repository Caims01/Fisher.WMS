/*
 * date：2022-12-21
 * developer：NoNo
 */
using Fisher.WMS.Core.JWT;
using Fisher.WMS.Core.Models;
using Fisher.WMS.Core.Services;
using Fisher.WMS.Web.Entities.Models;
using Fisher.WMS.Web.Entities.ViewModels;
 
 namespace Fisher.WMS.Web.IServices
 {
    /// <summary>
    /// Interface of SpuService
    /// </summary>
    public interface ISpuService : IBaseService<SpuEntity>
    {
        #region Api
        /// <summary>
        /// page search
        /// </summary>
        /// <param name="pageSearch">args</param>
        /// <param name="currentUser">currentUser</param>
        /// <returns></returns>
        Task<(List<SpuBothViewModel> data, int totals)> PageAsync(PageSearch pageSearch, CurrentUser currentUser);
        /// <summary>
        /// Get a record by id
        /// </summary>
        /// <param name="id">primary key</param>
        /// <returns></returns>
        Task<SpuBothViewModel> GetAsync(int id);
        /// <summary>
        /// get sku info by sku_id
        /// </summary>
        /// <param name="sku_id">sku_id</param>
        /// <returns></returns>
        Task<SkuDetailViewModel> GetSkuAsync(int sku_id);
        /// <summary>
        /// add a new record
        /// </summary>
        /// <param name="viewModel">viewmodel</param>
        /// <param name="currentUser">currentUser</param>
        /// <returns></returns>
        Task<(int id, string msg)> AddAsync(SpuBothViewModel viewModel, CurrentUser currentUser);
        /// <summary>
        /// update a record
        /// </summary>
        /// <param name="viewModel">viewmodel</param>
        /// <returns></returns>
        Task<(bool flag, string msg)> UpdateAsync(SpuBothViewModel viewModel);

        /// <summary>
        /// delete a record
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        Task<(bool flag, string msg)> DeleteAsync(int id);
        #endregion
    }
 }
 
