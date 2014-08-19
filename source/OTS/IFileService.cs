namespace OTS
{
    public interface IFileService
    {
        bool HasFileToProcess();
        void ProcessFile();
    }
}