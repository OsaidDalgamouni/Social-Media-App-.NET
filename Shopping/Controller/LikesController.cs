using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Helpers;
using Service.IService;
using Service.Extentions;
using Domain.Models;
using Service.DTO;

namespace Shopping.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(LogUserActivity))]
    [Authorize]
    public class LikesController : ControllerBase
    {
        private readonly IUnitOfWorkService _unit;

        public LikesController(IUnitOfWorkService unit)
        {
            _unit = unit;
        }
        [HttpPost("{userName}")]
        public ActionResult AddLike(string userName)
        {
            // GetUserId() it is in claimExtention
            var SourceUserId =int.Parse(User.GetUserId());
            var likedUser=_unit.UserService.SearchByusername(userName);
            var sourceUser = _unit.LikeService.GetUserWithLikes(SourceUserId);
            if (likedUser == null) return NotFound();
            if (sourceUser.Username == userName) return BadRequest("You can't Like Your Self");
            var userLike = _unit.LikeService.GetUserLike(SourceUserId, likedUser.Id);
            if (userLike != null) return BadRequest("You already Like this user ");
            userLike = new Like
            {
                Sourceuserid = SourceUserId,
                Targetuserid = likedUser.Id,

            };
            _unit.UserService.SaveLikeinDb(sourceUser, userLike);
            _unit.Save();

            return Ok();
        }
        [HttpGet]
        public ActionResult<PagedList<LikeDto>> GetUserLikes(string prdicate, [FromQuery] LikesParams likesParams)
        {
            var users =_unit.LikeService.GetUserLikes(prdicate,int.Parse(User.GetUserId()), likesParams);
            Response.AddPagenationHeader(header: new PaginationHeader
                 (users.CurrentPage, users.PageSize, users.TotalCount, users.TotalPages));
            return Ok(users);

        }
    }
}
