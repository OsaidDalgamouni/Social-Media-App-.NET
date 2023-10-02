using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IPhotoRepository :IRepository<Photo>
    {
        Photo UpdatePhoto(User user, decimal photoId);
        Photo GetMainPhoto(User user);

    }
}
