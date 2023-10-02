using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Repository.IRepository;
using Service.Helpers;
using Service.IService;

namespace Service.Service
{
    public class PhotoService : IPhotoService
    {
        private readonly Cloudinary _cloudinary;
        private readonly IUnitOfWork unitOfWork;
        public PhotoService(IUnitOfWork un,IOptions<CloudinarySetting> options)
        {
            unitOfWork = un;
            var acc = new Account(
                options.Value.CloudName,
                options.Value.ApiKey,
                options.Value.ApiSecret

                );
            _cloudinary = new Cloudinary(acc);
         

        }

        public ImageUploadResult AddPhoto(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();
            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParam = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face"),
                    Folder = "da-net6"
                };
                uploadResult=_cloudinary.Upload(uploadParam);
               
            }
            return uploadResult;
        }

        public DeletionResult DeletePhoto(string PublicId)
        {
            var DeleteParam=new DeletionParams(PublicId);
            return _cloudinary.Destroy(DeleteParam);
        }
        public void DeletePhotoDB(Photo photo)
        {
            unitOfWork.Photo.Remove(photo);
        }
        public Photo GetMainPhoto(User user)
        {
           return unitOfWork.Photo.GetMainPhoto(user);
        }

        public Photo GetPhotoById(decimal id)
        {
            var photo = unitOfWork.Photo.GetFirstOrDefualt(u => u.Id == id);
            return photo;
        }

        public Photo UpdatePhoto(User user, decimal photoId)
        {
           return unitOfWork.Photo.UpdatePhoto(user, photoId);
        }
       
    }
}
