using static WebStore.Helpers.FileHelper;

namespace WebStore.Helpers.IHelpers
{
    public interface IFileHelper
    {
        public string WebRootPath { get; }

        string ProductImagesFolderPath { get; }

        string RelativeProductImagesFolderPath { get; }

        string GetBase64SrcData(string src);

        byte[] CreateArchive(List<(Stream Stream, string Name)> memoryDatas, List<(string DiskLink, string EntryPath)> diskFilesLocation);

        Stream GetStreamFromString(string content);

        string GetJsonFromModel<T>(T products);
    }
}
