
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Fisher.WMS.Core.JWT;
using Fisher.WMS.Core.Utility;
using System.Linq;

namespace Fisher.WMS.Core.Controller
{
    /// <summary>
    /// base controller
    /// </summary>
    //[Authorize] 
    [Produces("application/json")]
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// current user
        /// </summary>
        public CurrentUser CurrentUser
        {
            get
            {
                if (User != null && User.Claims.ToList().Count > 0)
                {
                    var Claim = User.Claims.First(claim => claim.Type == ClaimValueTypes.Json);
                    return Claim == null ? new CurrentUser() : JsonHelper.DeserializeObject<CurrentUser>(Claim.Value);
                }
                else
                {
                    return new CurrentUser();
                }
            }
        }

        public BaseController()
        {
        }
    }
}
