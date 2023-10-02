using AutoMapper;
using Domain.Models;
using Service.DTO;
using Service.Service;

namespace Service.Helpers
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, MemberDTO>().ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.Ismain).Url))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Dateofbirth.Calulate()));
            CreateMap<Photo, PhotoDTO>();
            CreateMap<UpdateMemberDTO, User>();
            CreateMap<RegisterDto, User>();
            CreateMap<User,LikeDto>();
            CreateMap<Message, MessageDTO>()
                .ForMember(dest => dest.SenderPhotoUrl
                , opt => opt.MapFrom
                 (src => src.Sender.Photos.FirstOrDefault(x => x.Ismain).Url))
                .ForMember(dest => dest.RecipientPhotoUrl
                , opt => opt.MapFrom
                 (src => src.Recipient.Photos.FirstOrDefault(x => x.Ismain).Url)); 
      



        }
    }
}
