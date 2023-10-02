using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.Helpers;
using Service.IService;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace Shopping.Controller
{
    [ServiceFilter(typeof(LogUserActivity))]
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWorkService _unitOfWorkService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        public AccountController(IUnitOfWorkService unitOfWorkService, IAuthenticationService authenticationService, IMapper mapper)
        {
            _unitOfWorkService = unitOfWorkService;
            _authenticationService = authenticationService;
            _mapper = mapper;
        }
        [HttpPost("register")]
        public async Task<ActionResult<Authentication>> CreateAccount(RegisterDto registerDto)
        {
            if ( userExist(registerDto.Username)!=null) return BadRequest("User exist");
            if (ModelState.IsValid == false)
            {
                string errorMassage = string.Join("|", ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Problem(errorMassage);
            }
            var user = _mapper.Map<User>(registerDto);
            using var hmac = new HMACSHA512();
            //CREATE USER
            user.Username = registerDto.Username.ToLower();
            user.Hashpassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.password));
            user.Saltpassword = hmac.Key;
            _unitOfWorkService.UserService.add(user);
            _unitOfWorkService.Save();
            return new Authentication
            {
                Username = user.Username,
                Token = _authenticationService.CreateJWT(user),
                KnownAS=user.Knownas,
                Gender = user.Gender

            };
        }

        [HttpPost("login")]
        public ActionResult<Authentication> Login(LoginDTO loginDTO)
        {
            if (ModelState.IsValid == false)
            {
                string errorMassage = string.Join("|", ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Problem(errorMassage);
            }


            var getuser = _unitOfWorkService.UserService.GetbyId(u => u.Username == loginDTO.Username, "Photos");
            if (getuser == null) { return Unauthorized(); }
            using var hmac = new HMACSHA512(getuser.Saltpassword);

            var hashpassord = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));

            for (int i = 0; i < hashpassord.Length; i++)
            {
                if (hashpassord[i] != getuser.Hashpassword[i]) { return Unauthorized("Invalid Password"); }
            }
            return new Authentication
            {

                Username = getuser.Username,
                Token = _authenticationService.CreateJWT(getuser),
                PhotoUrl=_unitOfWorkService.ImageService.GetMainPhoto(getuser)?.Url,
                KnownAS=getuser.Knownas,
                Gender=getuser.Gender

            };

        }
        private  User userExist(string username)
        {
            return  _unitOfWorkService.UserService.SearchByusername(username.ToLower());
        }

    }
}
