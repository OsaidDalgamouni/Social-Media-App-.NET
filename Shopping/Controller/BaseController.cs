using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{

    [ApiController]
    public class BaseController : Controller
    {
        private readonly IConfiguration _configuration;
        private IHttpContextAccessor _httpContextAccessor;


        public BaseController(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;

            if (_httpContextAccessor.HttpContext.Request.Headers != null)
            {
                var authToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].FirstOrDefault();

                if (!string.IsNullOrEmpty(authToken))
                {
                    string output = authToken.Substring("Bearer ".Length).Trim();
                }

                var identity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
                var claim = (identity).FindFirst(ClaimTypes.UserData);
                if (claim != null)
                {
                    var userInfo = claim.Value;
                    //loginDTO = JsonConvert.DeserializeObject<LoginDTO>(userInfo);
                    //CreditInsuranceDBContext.userName = loginDTO.userName;
                    //CreditInsuranceDBContext.userInfo = JsonConvert.SerializeObject(loginDTO);
                }

            }
        }
    }
}
