using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IUnitOfWorkService
    {
        
        IUserService UserService { get; }
        IPhotoService ImageService { get; }
        ILikeService LikeService { get; }
        IMessageService MessageService { get; }
        
       
        void Save();
    }
}
