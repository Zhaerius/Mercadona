using Application.Core.Abstractions;
using Application.Core.Features.Upload.Commands.SaveFiles;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services
{
    public class FileService : IFileService
    {
        private readonly IConfiguration _configuration;

        public FileService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<UploadResult>> SaveFile(IFormFileCollection files)
        {
            var maxAllowedFiles = 1;
            long maxFileSize = 1024 * 500;
            var filesProcessed = 0;
            List<UploadResult> uploadResults = new();

            foreach (var file in files)
            {
                var extension = new FileInfo(file.FileName).Extension;

                var uploadResult = new UploadResult();
                uploadResult.FileName = file.FileName;
                string trustedFileNameForFileStorage;


                if (filesProcessed < maxAllowedFiles)
                {
                    if (file.Length == 0)
                    {
                        uploadResult.ErrorCode = 1;
                    }
                    else if (file.Length > maxFileSize)
                    {
                        uploadResult.ErrorCode = 2;
                    }
                    else
                    {
                        try
                        {
                            trustedFileNameForFileStorage = Path.GetRandomFileName().Replace(".", "");
                            var path = Path.Combine(_configuration["PathFileImg"]!, trustedFileNameForFileStorage + extension);

                            await using FileStream fs = new(path, FileMode.Create);
                            await file.CopyToAsync(fs);

                            uploadResult.Uploaded = true;
                            uploadResult.StoredFileName = trustedFileNameForFileStorage;
                        }
                        catch (IOException ex)
                        {
                            uploadResult.ErrorCode = 3;
                        }
                    }

                    filesProcessed++;
                }
                else
                {
                    uploadResult.ErrorCode = 4;
                }

                uploadResults.Add(uploadResult);
            }

            return uploadResults;
        }
    }
}
