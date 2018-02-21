using System;
using System.IO;

namespace FrameworkCommon.Toolbox
{
    public class FileUtils
    {
        /// <summary>
        /// Opens a file, appends the specified string to the file, and then closes the file. 
        /// If the file does not exist, this method creates a file, writes the specified 
        /// string to the file, then closes the file.
        /// </summary>
        /// <param name="path">The file to append the specified string to.</param>
        /// <param name="contents">The string to append to the file.</param>
        /// <param name="newLine">(Optional) Flag to enter text as a new line to the file.</param>
        public static void AppendTxtToFile(string path, string contents, bool newLine = true)
        {
            if (newLine)
            {
                File.AppendAllText(path, Environment.NewLine + contents);

            }
            else
            {
                File.AppendAllText(path, contents);
            }
        }

        /// <summary>
        /// Creates or overwrites a file in the specified path.
        /// </summary>
        /// <param name="path">The path and name of the file to create.</param>
        public static void CreateFile(string path)
        {
            // Create the file
            FileStream fileStream = File.Create(path);
            // Close the file stream
            fileStream.Close();
        }

        /// <summary>
        /// Deletes all files in the given directory.
        /// </summary>
        /// <param name="directoryPath">The directory to remove all files from.</param>
        public static void DeleteAllFilesInDirectory(string directoryPath)
        {
            DirectoryInfo di = new DirectoryInfo(directoryPath);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }

        /// <summary>
        /// Deletes the contents of the current user's "Downloads" folder
        /// </summary>
        /// <returns></returns>
        public static void DeleteDownloads()
        {
            // Get the default downloads folder for the current user
            string downloadFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
            // Delete all existing files
            DeleteAllFilesInDirectory(downloadFolderPath);
        }

        /// <summary>
        /// Deletes the specified file.
        /// </summary>
        /// <param name="path">The name of the file to be deleted. Wildcard characters are not supported.</param>
        public static void DeleteFile(string path)
        {
            try { File.Delete(path); } catch { /* do nothing */ }
        }

        /// <summary>
        /// Looks for any file within the current user's "Download" folder.
        /// </summary>
        /// <param name="fileExtension">(Optional) The file extension type filter</param>
        public static bool LocateDownloadedFile(string fileExtension = "")
        {
            // Get the default downloads folder for the current user
            string downloadFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
            DirectoryInfo di = new DirectoryInfo(downloadFolderPath);
            FileInfo[] foundFiles;
            if (fileExtension.Length > 0)
            {
                foundFiles = di.GetFiles(fileExtension);
            }
            else
            {
                foundFiles = di.GetFiles();
            }
            // Return if files were found
            if (foundFiles.Length == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
