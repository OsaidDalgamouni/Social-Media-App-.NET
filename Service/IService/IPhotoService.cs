using CloudinaryDotNet.Actions;
using Domain.Models;
using Microsoft.AspNetCore.Http;

namespace Service.IService
{
    public interface IPhotoService
    {
        ImageUploadResult AddPhoto(IFormFile file);
        DeletionResult DeletePhoto(string PublicId);
        void DeletePhotoDB(Photo photo);
        Photo UpdatePhoto(User user, decimal photoId);
        Photo GetMainPhoto(User user);
        Photo GetPhotoById(decimal id);
    }
}
