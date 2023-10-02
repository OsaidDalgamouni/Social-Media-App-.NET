using AutoMapper;
using Domain.Models;
using Repository.IRepository;
using Service.DTO;
using Service.Extentions;
using Service.Helpers;
using Service.IService;
using System.Linq.Expressions;
using System.Security.Principal;

namespace Service.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private IMapper _mapper;




        public UserService(IUnitOfWork un ,IMapper mapper )
        {
            unitOfWork = un;
            _mapper = mapper;
        
            
        }
        public void add(User item)
        {
            unitOfWork.User.add(item);
        }

        public void AddPhoto(User user, Photo photo)
        {
            unitOfWork.User.AddPhoto(user, photo);
        }
        public void RemovePhoto(User user, Photo photo)
        {
            unitOfWork.User.RemovePhoto(user, photo);
        }

        public IEnumerable<User> GetAll(string? Includeproperities = null)
        {
            if (Includeproperities != null)
            {
                return unitOfWork.User.GetAll(Includeproperities);
            }
            return unitOfWork.User.GetAll();
        }

        public User GetbyId(Expression<Func<User, bool>> filter,string? Includeproperities = null)
        {
            if (Includeproperities != null)
            {
              return  unitOfWork.User.GetFirstOrDefualt(filter, Includeproperities);
            }

            return unitOfWork.User.GetFirstOrDefualt(filter);
            
        }

        public void Remove(User item)
        {
            unitOfWork.User.Remove(item);
        }

        public User SearchByusername(string usernme)
        {
            return  unitOfWork.User.SearchByusername(usernme);
        }

            public void update(User item)
        {
            unitOfWork.User.updateUser(item);
        }
        public  PagedList<MemberDTO>GetAllMember(UserParams userParams, string? Includeproperities = null)
        {
            var minDob = DateTime.Today.AddYears(-userParams.MaxAge - 1);
            var maxDob = DateTime.Today.AddYears(-userParams.MinAge);
            var member = unitOfWork.User.GetMemberByCondition(u =>   u.Username != userParams.CurruntUserName &&  u.Gender == userParams.Gender && u.Dateofbirth >= minDob && u.Dateofbirth <= maxDob, Includeproperities );

          /*  member = unitOfWork.User.GetMemberByCondition(u => u.Username != userParams.CurruntUserName, Includeproperities);

            member = unitOfWork.User.GetMemberByCondition(u => u.Gender == userParams.Gender, Includeproperities);*/
            
            member = userParams.OrderBy switch
            {
                "created" => member.OrderByDescending(u => u.Created),
                _ => member.OrderByDescending(u => u.Lastactive),
            };
            member.ToList();
            var usertoreturn=_mapper.Map<IEnumerable< MemberDTO>>(member);
            return  PagedList<MemberDTO>.Create(usertoreturn, userParams.PageNumber, userParams.PageSize);
         
        }
        public void SaveLikeinDb(User user, Like like)
        {
            unitOfWork.User.SaveLikeinDb(user, like);

        }


    }
}
