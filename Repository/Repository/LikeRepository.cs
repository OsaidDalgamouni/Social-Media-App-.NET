using Domain.Models;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class LikeRepository : Repository<Like>, ILikeRepository
    {
        private readonly ModelContext _db;
        public LikeRepository(ModelContext db) : base(db)
        {
            _db = db;
        }

        public Like GetUserLike(decimal sourceuserid, decimal targetuserid)
        {
           return _db.Likes.FirstOrDefault(x=>x.Sourceuserid==sourceuserid && x.Targetuserid==targetuserid);
           

        }

        public IEnumerable<User> GetUserLikes(string predicate, decimal id)
        {
            var user = _db.Users.OrderBy(u => u.Username).AsQueryable();
            var likes=_db.Likes.AsQueryable();
           

            if(predicate == "liked")
            {
                likes = likes.Where(like => like.Sourceuserid == id);
                user=likes.Select(like => like.Targetuser);
            }
            if (predicate == "likedBy")
            {
                likes = likes.Where(like => like.Targetuserid == id);
                user = likes.Select(like => like.Sourceuser);
            }
            return user;

        }
          
    }
}
