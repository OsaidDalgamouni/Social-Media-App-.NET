using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }
        IPhotoRepository Photo { get; }
        ILikeRepository Like { get; }
        IMessageRepository Message { get; }
      
        
        void Save();
    }
}
