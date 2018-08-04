using System.Threading.Tasks;
using Model.Models.Authentication;

namespace Application.Modules.Interfaces
{
    public interface IFileUploadApplication : IBaseApplication
    {
        Task<string> AddFile(byte[] file,
            string fileName,
            string contentType,
            AuthenticatedModel loggedInUser);
    }
}
