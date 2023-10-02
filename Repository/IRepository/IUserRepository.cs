using Domain.Models;
using System.Linq.Expressions;

namespace Repository.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
         User SearchByusername(string usernme);
        void AddPhoto(User user, Photo photo);
        void RemovePhoto(User user, Photo photo);
         IQueryable<User> GetMemberByCondition(Expression<Func<User, bool>> filter, string? includeproperty = null);

        void updateUser(User user);

        User GetUserWithLikes(decimal userId);
        void SaveLikeinDb(User user, Like like);
        IEnumerable<User> GetUserLikes(string predicate, decimal id);









    }
}
