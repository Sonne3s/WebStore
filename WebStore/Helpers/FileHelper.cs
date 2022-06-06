using Microsoft.AspNetCore.StaticFiles;
using Newtonsoft.Json;
using System.IO.Compression;
using System.Text;
using WebStore.Helpers.IHelpers;

namespace WebStore.Helpers
{
    public class FileHelper : IFileHelper
    {
        private IWebHostEnvironment _hostingEnvironment;
        private IContentTypeProvider _contentTypeProvider;
        private string _relativeProductImagesFolderPath;

        

        public string WebRootPath { get { return _hostingEnvironment.WebRootPath; } }

        public string ProductImagesFolderPath { get { return Path.Combine(_hostingEnvironment.WebRootPath, _relativeProductImagesFolderPath); } }

        public string RelativeProductImagesFolderPath { get { return _relativeProductImagesFolderPath; } }


        public FileHelper(IWebHostEnvironment hostingEnvironment, IContentTypeProvider contentTypeProvider)
        {
            _hostingEnvironment = hostingEnvironment;
            _contentTypeProvider = contentTypeProvider;
            _relativeProductImagesFolderPath = Path.Combine("img", "products");
        }

        public string GetBase64SrcData(string src)
        {
            string contentType;
            _contentTypeProvider.TryGetContentType(src, out contentType);
            var path = Path.Combine(this.WebRootPath, src);
            var file = File.ReadAllBytes(path);
            var base64 = Convert.ToBase64String(file);

            return $"data:{ contentType };base64,{ base64 }";
        }

        #region Export
        public byte[] CreateArchive(List<(Stream Stream, string Name)> memoryDatas, List<(string DiskLink, string EntryPath)> diskFilesLocation)
        {
            using (MemoryStream zipStream = new MemoryStream())
            {
                using (var archive = new ZipArchive(zipStream, ZipArchiveMode.Create, leaveOpen: true))
                {
                    foreach(var fileStream in memoryDatas)
                    {
                        var entry = archive.CreateEntry(fileStream.Name, CompressionLevel.Fastest);
                        using (Stream stream = entry.Open())
                        {
                            fileStream.Stream.CopyTo(stream);
                        }
                    }

                    foreach (var link in diskFilesLocation)
                    {
                        archive.CreateEntryFromFile(link.DiskLink, link.EntryPath);//Path.Combine(_hostingEnvironment.WebRootPath, img.Src), img.Src);
                    }
                }// disposal of archive will force data to be written to memory stream.
                zipStream.Position = 0; //reset memory stream position.

                return zipStream.ToArray(); //get all flushed data
            }
        }

        public Stream GetStreamFromString(string content)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream, Encoding.Unicode);
            writer.Write(content);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public string GetJsonFromModel<T>(T products)
        {
            return JsonConvert.SerializeObject(products, Formatting.Indented,
            new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            });
        }

        #endregion

        #region Import

        public string ReadFileToString(Stream fileStream)
        {
            using var reader = new StreamReader(fileStream, Encoding.UTF8);

            return reader.ReadToEnd();
        }

        #endregion
    }
}
