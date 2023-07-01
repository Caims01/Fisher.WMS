using System.Collections.Generic;
using System.Threading.Tasks;
using Fisher.WMS.Core.JWT;
using Fisher.WMS.Core.Models;

namespace Fisher.WMS.Core.Services
{
    /// <summary>
    /// account service interface
    /// </summary>
    public interface IAccountService
    {

        /// <summary>
        /// login
        /// </summary>
        /// <param name="loginInput">user 's account infomation</param>
        /// <param name="currentUser">current user</param>
        /// <returns></returns>
        Task<LoginOutputViewModel> Login(LoginInputViewModel loginInput,CurrentUser currentUser);

        string HelloWorld();
    }
}
