using System;
using System.Threading.Tasks;
using Application.Modules.Interfaces;
using Application.Modules.Modules.Base;
using CrossCutting.Utils.Exceptions;
using CrossCutting.Utils.Extensions;
using CrossCutting.Utils.Utils;
using Microsoft.AspNetCore.Hosting;
using Model.Models.Authentication;

namespace Application.Modules.Modules.FileUpload
{
    //we don't create a domain for the file upload application since it is not business
    //domain specific and there is no point of holding processes in here aswell
    public class FileUploadApplication : BaseApplication, IFileUploadApplication
    {
        private IHostingEnvironment HostingEnvironment { get; }

        public FileUploadApplication(IHostingEnvironment hostingEnvironment)
        {
            HostingEnvironment = hostingEnvironment;
        }

        public async Task<string> AddFile(byte[] file,
            string fileName,
            string contentType,
            AuthenticatedModel loggedInUser)
        {
            var systemGeneratedOutputPath =
                FileSystemNamingUtil.CreateOutputPath(HostingEnvironment.ContentRootPath, fileName, loggedInUser.UserName);

            systemGeneratedOutputPath.EnsureFolderCreatedFromFolderPath();

            try
            {
                System.IO.File.WriteAllBytes(systemGeneratedOutputPath, file);
            }
            catch (Exception ex)
            {
                throw new DomainException($"File content for {fileName} can't be read. Reason: {ex.Message}");
            }

            return FileSystemNamingUtil.GetRelativeFilePath(HostingEnvironment.ContentRootPath, systemGeneratedOutputPath);
        }

    }
}
