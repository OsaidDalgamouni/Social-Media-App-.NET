using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface ILikeRepository : IRepository<Like>
    {
        Like GetUserLike(decimal sourceuserid, decimal targetuserid);
        IEnumerable<User> GetUserLikes(string predicate, decimal id);
       
    }
}
