using AutoMapper;
using Domain.Models;
using Repository.IRepository;
using Service.DTO;
using Service.Extentions;
using Service.Helpers;
using Service.IService;
using System.Linq.Expressions;

namespace Service.Service
{
    public class LikeService : ILikeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public LikeService(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void add(Like item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Like> GetAll(string? Includeproperities = null)
        {
            throw new NotImplementedException();
        }

        public Like GetbyId(Expression<Func<Like, bool>> filter, string? Includeproperities = null)
        {
            throw new NotImplementedException();
           
        }

        public Like GetUserLike(decimal sourceuserid, decimal targetuserid)
        {
            var like=_unitOfWork.Like.GetUserLike(sourceuserid, targetuserid);
            return like;
        }

        public PagedList<LikeDto> GetUserLikes(string predicate, decimal id,LikesParams? likesParams)
        {
            var like =_unitOfWork.User.GetUserLikes(predicate, id);

            var likedUser= like.Select(like => new LikeDto { 
                UserName=like.Username,
                Country=like.Country,
                Id=like.Id,
                City=like.City,
                Knownas=like.Knownas,
                PhotoUrl=like.Photos.FirstOrDefault(u=>u.Ismain)?.Url,
            });
            return PagedList<LikeDto>.Create(likedUser, likesParams.PageNumber,likesParams.PageSize);

        }

        public User GetUserWithLikes(decimal userId)
        {
          var userWithLike=_unitOfWork.User.GetUserWithLikes(userId);
            return userWithLike;
        }
       

        public void Remove(Like item)
        {
            throw new NotImplementedException();
        }

        public void update(Like item)
        {
            throw new NotImplementedException();
        }
    }
}
