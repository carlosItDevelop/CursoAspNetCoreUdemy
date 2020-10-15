using Microsoft.AspNetCore.Http;

namespace Cooperchip.ITDeveloper.Mvc.Infra
{
    public interface IUnitOfUpload
    {
        void UploadImage(IFormFile file);
    }
}
