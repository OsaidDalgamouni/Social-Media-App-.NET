using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.Helpers;
using Service.IService;
using System.Security.Claims;
using Service.Extentions;


namespace Shopping.Controller
{
    [ServiceFilter(typeof(LogUserActivity))]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWorkService _unitOfWorkService;
        private readonly IMapper _mapper;

        public UsersController(IUnitOfWorkService unitOfWorkService, IMapper mapper)
        {
            _unitOfWorkService = unitOfWorkService;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<MemberDTO> GetAll([FromQuery]UserParams userParams)
        {
          
            var username = User.GetUserName();
            var curruntuser = _unitOfWorkService.UserService.SearchByusername(username);
            userParams.CurruntUserName = curruntuser.Username;
            if (string.IsNullOrEmpty(userParams.Gender))
            {
                userParams.Gender = curruntuser.Gender == "male" ? "female" : "male";
            }
            var user = _unitOfWorkService.UserService.GetAllMember(userParams, Includeproperities: "Photos");
            Response.AddPagenationHeader(new PaginationHeader
                   (user.CurrentPage, user.PageSize, user.TotalCount, user.TotalPages));

            return Ok(user);

        }
        [HttpGet("username")]
        public ActionResult<MemberDTO> GetUser(string name)
        {
            var user = _unitOfWorkService.UserService.SearchByusername(name);
            


            return _mapper.Map<MemberDTO>(user);

        }

        [HttpPut]
        public ActionResult UpdateMember(UpdateMemberDTO updateMemberDTO)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = _unitOfWorkService.UserService.SearchByusername(username);
            if (user == null)
            {
                return Problem();
            }


            _mapper.Map(updateMemberDTO, user);//its send data that in property in dto to user 
                                               //entity without save change in database 
                                               //_unitOfWorkService.UserService.update(user);
            _unitOfWorkService.Save();

            return NoContent();
        }
        [HttpPost("add-photo")]

        public ActionResult<PhotoDTO> AddPhoto(IFormFile file)
        {
            var user = _unitOfWorkService.UserService.SearchByusername(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (user == null) return NotFound();
            var result = _unitOfWorkService.ImageService.AddPhoto(file);
            if (result.Error != null) return BadRequest(result.Error.Message);
            Photo photo = new Photo
            {
                Url = result.SecureUrl.AbsoluteUri,
                Publicid = result.PublicId,
                Ismain = false,
            };
            if (user.Photos.Count == 0)
            {
                photo.Ismain = true;
            }
            _unitOfWorkService.UserService.AddPhoto(user, photo);
            _unitOfWorkService.Save();

            return CreatedAtAction(nameof(GetUser),
                new { username = user.Username }, _mapper.Map<PhotoDTO>(photo));
        }

        [HttpPut("set-main-photo{photoId}")]
        public ActionResult<PhotoDTO>SetMainPhoto(decimal photoId)
        {
            var user = _unitOfWorkService.UserService.SearchByusername(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if(user == null) return NotFound();
            var photo= _unitOfWorkService.ImageService.UpdatePhoto(user, photoId);
            if (photo == null) { return NotFound(); }
            if (photo.Ismain) { return BadRequest("Photo is main "); }
            var currentMainPhoto=_unitOfWorkService.ImageService.GetMainPhoto(user);
            if (currentMainPhoto != null) { currentMainPhoto.Ismain = false; }
            photo.Ismain = true;
            _unitOfWorkService.Save();
            return NoContent();
        }

        [HttpDelete("dalete-photo{photoId}")]
        public ActionResult DeletePhoto(decimal photoId)
        {
            //var user = _unitOfWorkService.UserService.SearchByusername(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            //if (user == null) return NotFound();
            var photo = _unitOfWorkService.ImageService.GetPhotoById(photoId);
            if (photo == null) { return NotFound(); }
            if (photo.Ismain) { return BadRequest("Photo is main"); }
            if (photo.Publicid != null)
            {
                var result = _unitOfWorkService.ImageService.DeletePhoto(photo.Publicid);

                if (result.Error != null) return BadRequest(result.Error.Message);
            }
            //user.Photos.Remove(photo);
            //_unitOfWorkService.UserService.RemovePhoto(user, photo);
            _unitOfWorkService.ImageService.DeletePhotoDB(photo);
            _unitOfWorkService.Save();
            return Ok();
        }
    }
}
