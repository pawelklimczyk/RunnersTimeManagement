// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="FileService.cs" project="RunnersTimeManagement.ClientServices" date="2014-06-04 09:59">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.ClientServices
{
    using System;
    using System.IO;
    using System.IO.IsolatedStorage;
    using System.Threading;

    public class FileService : IFileService
    {
        public bool TryReadTextFile(string path, out string contents)
        {
            contents = String.Empty;

            try
            {
                using (var isf = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    if (!isf.FileExists(path))
                    {
                        return false;
                    }

                    using (var fileStream = isf.OpenFile(path, FileMode.Open))
                    {
                        using (var streamReader = new StreamReader(fileStream))
                        {
                            contents = streamReader.ReadToEnd();
                        }
                    }
                }
            }
            catch (ThreadAbortException e)
            {
                LoggingService.LogException(e);
                throw;
            }
            catch (Exception e)
            {
                LoggingService.LogException(e);
                return false;
            }

            return true;
        }

        public bool TryWriteTextFile(string path, string contents)
        {
            try
            {
                using (var isf = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (var fileStream = new IsolatedStorageFileStream(path, FileMode.Create, isf))
                    {
                        using (var sw = new StreamWriter(fileStream))
                        {
                            sw.Write(contents);
                            sw.Flush();
                            return true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                LoggingService.LogException(e);
                throw;
            }
        }
    }
}
