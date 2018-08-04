using System;
using System.Linq;
using CrossCutting.Resources;
using CrossCutting.Utils.Extensions;
using CrossCutting.Security.Hash;

namespace CrossCutting.Utils.Utils
{
    public static class FileSystemNamingUtil
    {
        public static string CreateFolderNameFromUserName(string userName)
            => $"{userName.RemoveSpecialCharacters().Replace(".", string.Empty)}{new Hash().Create(userName).RemoveSpecialCharacters().Substring(0, 5)}";

        public static string CreateFileName(string fileNameWithExtension,
            bool shortenFileName = false,
            short shortenedLength = 10)
        {
            var fileName =
               $"{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}_{ClearFileName(fileNameWithExtension.Replace(GetFileExtension(fileNameWithExtension), string.Empty))}";

            return shortenFileName ? fileName.Substring(0, shortenedLength) : fileName;
        }

        public static string CreateOutputPath(string contentRootPath,
            string fileName,
            string userName,
            bool shortenFileName = false,
            short shortenedLength = 10)
           => $"{contentRootPath}\\{DesignAutomatorSettings.FileUploadRootPath}\\{CreateFolderNameFromUserName(userName)}\\{CreateFileName(fileName, shortenFileName, shortenedLength)}.{GetFileExtension(fileName)}";

        public static string GetFileExtension(string fileName)
            => fileName.Split('.').Last();

        public static string ClearFileName(string fileName)
            => fileName.Replace(" ", string.Empty).Replace("-", string.Empty).Replace(".", string.Empty);

        public static string GetRelativeFilePath(string contentRootPath, string systemGeneratedOutputPath) =>
            systemGeneratedOutputPath.Replace(contentRootPath, string.Empty)
                .Replace(DesignAutomatorSettings.FileUploadRootPath, string.Empty)
                .Trim('\\');
    }
}
