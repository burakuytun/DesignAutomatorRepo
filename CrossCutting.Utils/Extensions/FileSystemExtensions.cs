using System.IO;

namespace CrossCutting.Utils.Extensions
{
   public  static class FileSystemExtensions
    {
        public static void EnsureFolderCreatedFromFolderPath(this string fullFilePath)
        {
            if (!Directory.Exists(Path.GetDirectoryName(fullFilePath)))
                Directory.CreateDirectory(fullFilePath);
        }
    }
}
