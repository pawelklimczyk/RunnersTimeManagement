namespace RunnersTimeManagement.ClientServices
{
    public interface IFileService
    {
        bool TryReadTextFile(string path, out string contents);

        bool TryWriteTextFile(string path, string contents);
    }
}