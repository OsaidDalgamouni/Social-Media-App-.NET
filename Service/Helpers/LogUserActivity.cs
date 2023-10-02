using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Service.Extentions;
using Service.IService;

namespace Service.Helpers
{
    public class LogUserActivity : IAsyncActionFilter
    {

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var ResultContext = await next();
            if (!ResultContext.HttpContext.User.Identity.IsAuthenticated) return;

            var userId= ResultContext.HttpContext.User.GetUserName();

            var AccessService = ResultContext.HttpContext.RequestServices.GetRequiredService<IUnitOfWorkService>();
            var User= AccessService.UserService.SearchByusername(userId);
            User.Lastactive=DateTime.Now;
            AccessService.Save();
        }
    }
}
