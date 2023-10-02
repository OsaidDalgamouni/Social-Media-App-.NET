using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Repository.IRepository;
using Repository.Repository;
using Service.Helpers;
using Service.IService;
using Service.Service;


namespace Service.UnitOfWork
{
    public class ServiceUnitOfWork : IUnitOfWorkService
    {
        private IUnitOfWork unit;
        private readonly IOptions<CloudinarySetting> _options;
        private IMapper _mapper;

        public IUserService UserService { get; private set; }
        public IPhotoService ImageService { get; private set; }
        public ILikeService LikeService { get; private set; }
        public IMessageService MessageService { get; private set; }



        public ServiceUnitOfWork(ModelContext contex, IOptions<CloudinarySetting> options, IMapper mapper)
        {
            unit = new UnitOfWorkRepository(contex);
            _options = options;
            _mapper = mapper;

            UserService =new UserService(unit,_mapper);
            ImageService= new PhotoService(unit,options);
            LikeService = new LikeService(unit, _mapper);
            MessageService= new MessageService(unit, _mapper);





        }

        public void Save()
        {
           unit.Save();
        }
    }
}
