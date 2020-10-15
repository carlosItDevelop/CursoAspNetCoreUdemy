using Microsoft.AspNetCore.Http;

namespace Cooperchip.ITDeveloper.Mvc.Intra
{
    public interface IUnitOfUpload
    {
        void UploadImage(IFormFile file);
    }
}
