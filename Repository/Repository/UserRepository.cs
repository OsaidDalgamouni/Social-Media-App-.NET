using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.IRepository;
using System.Linq.Expressions;

namespace Repository.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ModelContext _db;
        public UserRepository(ModelContext db) : base(db)
        {
            _db = db;
        }

        public void AddPhoto(User user, Photo photo)
        {
            user.Photos.Add(photo);

        }



        public void RemovePhoto(User user, Photo photo)
        {
            user.Photos.Remove(photo);
        }

        public User SearchByusername(string usernme)
        {
            var user = _db.Users.Include(x => x.Photos).AsTracking().FirstOrDefault(u => u.Username == usernme);
            return user;
        }


        public IQueryable<User> GetMemberByCondition(Expression<Func<User, bool>> filter, string? includeproperty = null)
        {

            var query = _db.Users.AsQueryable();
            query = query.Where(filter);
            if (includeproperty != null)
            {
                foreach (var prp in includeproperty.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(prp);
                }
            }

            return query;
        }

        public void updateUser(User user)
        {
            _db.Entry(user).State = EntityState.Modified;
        }

        public User GetUserWithLikes(decimal userId)
        {
            return _db.Users.Include(x => x.LikeSourceusers).FirstOrDefault(u => u.Id == userId);
        }
        public void SaveLikeinDb(User user, Like like)
        {
            user.LikeSourceusers.Add(like);
            _db.Update(user);

        }
        public IEnumerable<User> GetUserLikes(string predicate, decimal id)
        {
            var user = _db.Users.OrderBy(u => u.Username).AsQueryable();
            var likes = _db.Likes.Include(x=>x.Targetuser).ThenInclude(y => y.Photos).Include(z=>z.Sourceuser).ThenInclude(y=>y.Photos).AsQueryable();


            if (predicate == "liked")
            {
                likes = likes.Where(like => like.Sourceuserid == id);
                user = likes.Select(like => like.Targetuser);
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
