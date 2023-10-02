using Domain.Models;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class PhotoRepository : Repository<Photo>, IPhotoRepository
    {
        private readonly ModelContext _db;

        public PhotoRepository(ModelContext db) : base(db)
        {
            _db = db;
        }

        public Photo GetMainPhoto(User user)
        {
            return user.Photos.FirstOrDefault(x => x.Ismain);
        }

        public Photo UpdatePhoto(User user, decimal photoId)
        {
            var photo = user.Photos.FirstOrDefault(x => x.Id == photoId);
            if (photo == null)
            { }
                return photo;
        }
    }
}
