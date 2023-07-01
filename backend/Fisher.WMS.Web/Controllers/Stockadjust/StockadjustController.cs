/*
 * date：2022-12-26
 * developer：NoNo
 */
 using Microsoft.AspNetCore.Mvc;
 using Fisher.WMS.Core.Controller;
 using Fisher.WMS.Core.Models;
 using Fisher.WMS.Web.Entities.ViewModels;
 using Fisher.WMS.Web.IServices;
 using Microsoft.Extensions.Localization;
namespace Fisher.WMS.Web.Controllers
{
    /// <summary>
    /// stockadjust controller
    /// </summary>
     [Route("stockadjust")]
     [ApiController]
     [ApiExplorerSettings(GroupName = "WMS")]
     public class StockadjustController : BaseController
     {
         #region Args
 
         /// <summary>
         /// stockadjust Service
         /// </summary>
         private readonly IStockadjustService _stockadjustService;
 
         /// <summary>
         /// Localizer Service
         /// </summary>
         private readonly IStringLocalizer<Fisher.WMS.Core.MultiLanguage> _stringLocalizer;
         #endregion
 
         #region constructor
         /// <summary>
         /// constructor
         /// </summary>
         /// <param name="stockadjustService">stockadjust Service</param>
        /// <param name="stringLocalizer">Localizer</param>
         public StockadjustController(
             IStockadjustService stockadjustService
           , IStringLocalizer<Fisher.WMS.Core.MultiLanguage> stringLocalizer
             )
         {
             this._stockadjustService = stockadjustService;
            this._stringLocalizer= stringLocalizer;
         }
         #endregion
 
         #region Api
         /// <summary>
         /// page search
         /// </summary>
         /// <param name="pageSearch">args</param>
         /// <returns></returns>
         [HttpPost("list")]
         public async Task<ResultModel<PageData<StockadjustViewModel>>> PageAsync(PageSearch pageSearch)
         {
             var (data, totals) = await _stockadjustService.PageAsync(pageSearch, CurrentUser);
              
             return ResultModel<PageData<StockadjustViewModel>>.Success(new PageData<StockadjustViewModel>
             {
                 Rows = data,
                 Totals = totals
             });
         }
 
        #endregion

    }
 }
 
