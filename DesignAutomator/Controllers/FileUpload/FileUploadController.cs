using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.Modules.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Models.Authentication;
using Newtonsoft.Json;

namespace Web.DesignAutomator.Controllers.FileUpload
{
    [Route("api/FileUploadService/[action]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private IFileUploadApplication FileUploadApplication { get; }
        private IHostingEnvironment HostingEnvironment { get; }

        public FileUploadController(IFileUploadApplication fileUploadApplication,
                                    IHostingEnvironment hostingEnvironment)
        {
            HostingEnvironment = hostingEnvironment;
            FileUploadApplication
                = fileUploadApplication;
        }

        [HttpPost, DisableRequestSizeLimit]
        public async Task<ActionResult> Upload(IFormFile file)
        {
            AuthenticatedModel loggedInUser =
                JsonConvert.DeserializeObject<AuthenticatedModel>
                    (User.FindFirst(ClaimTypes.NameIdentifier).Value);

            if (file == null || file.Length == 0)
            {
                return NoContent();
            }

            string uploadedFolderPath = string.Empty;
            using (Stream stream = file.OpenReadStream())
            {
                using (var binaryReader = new BinaryReader(stream))
                {
                    var fileContent = binaryReader.ReadBytes((int)file.Length);
                    uploadedFolderPath = await FileUploadApplication.AddFile(fileContent,
                        file.FileName,
                        file.ContentType,
                        loggedInUser);
                }
            }

            return Ok(uploadedFolderPath);
        }
    }
}