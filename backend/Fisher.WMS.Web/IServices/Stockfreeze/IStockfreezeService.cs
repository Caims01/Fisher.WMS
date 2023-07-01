/*
 * date：2022-12-26
 * developer：NoNo
 */
 using Fisher.WMS.Core.Services;
 using Fisher.WMS.Core.Models;
 using Fisher.WMS.Core.JWT;
 using Fisher.WMS.Web.Entities.Models;
 using Fisher.WMS.Web.Entities.ViewModels;
 
 namespace Fisher.WMS.Web.IServices
 {
     /// <summary>
     /// Interface of StockfreezeService
     /// </summary>
     public interface IStockfreezeService : IBaseService<StockfreezeEntity>
     {
         #region Api
         /// <summary>
         /// page search
         /// </summary>
         /// <param name="pageSearch">args</param>
         /// <param name="currentUser">current user</param>
         /// <returns></returns>
         Task<(List<StockfreezeViewModel> data, int totals)> PageAsync(PageSearch pageSearch, CurrentUser currentUser);
         /// <summary>
         /// Get all records
         /// </summary>
         /// <returns></returns>
         Task<List<StockfreezeViewModel>> GetAllAsync(CurrentUser currentUser);
         /// <summary>
         /// Get a record by id
         /// </summary>
         /// <param name="id">primary key</param>
         /// <returns></returns>
         Task<StockfreezeViewModel> GetAsync(int id);
         /// <summary>
         /// add a new record
         /// </summary>
         /// <param name="viewModel">viewmodel</param>
         /// <param name="currentUser">current user</param>
         /// <returns></returns>
         Task<(int id, string msg)> AddAsync(StockfreezeViewModel viewModel, CurrentUser currentUser);
         /// <summary>
         /// update a record
         /// </summary>
         /// <param name="viewModel">viewmodel</param>
         /// <returns></returns>
         Task<(bool flag, string msg)> UpdateAsync(StockfreezeViewModel viewModel);
 
         /// <summary>
         /// delete a record
         /// </summary>
         /// <param name="id">id</param>
         /// <returns></returns>
         Task<(bool flag, string msg)> DeleteAsync(int id);
         #endregion
     }
 }
 
