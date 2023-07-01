using System.ComponentModel.DataAnnotations;

namespace Fisher.WMS.Core.Models
{
    /// <summary>
    /// RefreshTokenInPutViewModel
    /// </summary>
    public class RefreshTokenInPutViewModel
    {
        /// <summary>
        /// old access token
        /// </summary>
        [Required(ErrorMessage = "AccessToken  is Required")]
        public string AccessToken { get; set; }
        /// <summary>
        /// refresh token
        /// </summary>
        [Required(ErrorMessage = "RefreshToken is Required")]
        public string RefreshToken { get; set; }

    }
}
