using Domain.Models;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class UnitOfWorkRepository : IUnitOfWork
    {
        private readonly ModelContext _db;
        
      
        public IUserRepository User { get; private set; }
        public IPhotoRepository Photo { get; private set; }
        public ILikeRepository Like { get; private set; }
        public IMessageRepository Message { get; private set; }
  
      

        public UnitOfWorkRepository(ModelContext db)
        {
            _db = db;
            User= new UserRepository(_db);
            Photo= new PhotoRepository(_db);
            Like= new LikeRepository(_db);
            Message= new MessageRepository(_db);
           
        

        }
        public  void Save()
        {
            try
            {
                _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
    }
}
