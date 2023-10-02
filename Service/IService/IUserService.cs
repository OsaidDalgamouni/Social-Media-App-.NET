using Domain.Models;
using Service.DTO;
using Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IUserService :IService<User>
    {
        User SearchByusername(string usernme);
        void AddPhoto(User user,Photo photo);
        void RemovePhoto(User user,Photo photo);
        PagedList<MemberDTO> GetAllMember(UserParams userParams, string? Includeproperities = null);
        void SaveLikeinDb(User user, Like like);

    }
}
