using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.IService;

namespace Shopping.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BugController : ControllerBase
    {
        private readonly IUnitOfWorkService _unitOfWorkService;
        
        public BugController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
       
        }
        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "secret text";

        }
        [HttpGet("not-found")]
        public ActionResult<User> GetNotFound()
        { 

            var thing = _unitOfWorkService.UserService.GetbyId(u => u.Id == -1);
            if (thing == null) return NotFound();
            return thing;

        }
        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {

                var thing = _unitOfWorkService.UserService.GetbyId(u => u.Id == -1);
                var ThingToReturn = thing.ToString();
                return ThingToReturn;
            
            
            
            

            

         

        }
        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("this was not a good request");
         

        }
    }
}
