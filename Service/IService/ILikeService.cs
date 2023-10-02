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
    public interface ILikeService :IService<Like>
    {
        Like GetUserLike(decimal sourceuserid, decimal targetuserid);
        PagedList<LikeDto> GetUserLikes(string predicate, decimal id, LikesParams? likesParams);
        User GetUserWithLikes(decimal userId);

    

    }
}
