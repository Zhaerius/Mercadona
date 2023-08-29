using BlazorServer.BackOffice.Models.Article;
using BlazorServer.BackOffice.Services.Abstractions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http.Headers;
using System.Text.Json;

namespace BlazorServer.BackOffice.Pages.Article
{
    public class FilesUploadBase: ComponentBase
    {
        protected List<File> files = new();
        protected List<UploadResult> uploadResults = new();
        protected int maxAllowedFiles = 1;
        protected bool shouldRender;

        [Inject] protected IArticleService ArticleService { get; set; } = null!;
        protected override bool ShouldRender() => shouldRender;

        protected async Task OnInputFileChange(InputFileChangeEventArgs e)
        {
            shouldRender = false;
            long maxFileSize = 1024 * 1000;
            var upload = false;

            using var content = new MultipartFormDataContent();

            foreach (var file in e.GetMultipleFiles(maxAllowedFiles))
            {
                if (uploadResults.SingleOrDefault(f => f.FileName == file.Name) is null)
                {
                    try
                    {
                        files.Add(new() { Name = file.Name });

                        var fileContent = new StreamContent(file.OpenReadStream(maxFileSize));
                        fileContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

                        content.Add(
                            content: fileContent,
                            name: "\"files\"",
                            fileName: file.Name);

                        upload = true;
                    }
                    catch (Exception ex)
                    {
                        var result = new UploadResult()
                        {
                            FileName = file.Name,
                            ErrorCode = 6,
                            Uploaded = false
                        };
                        uploadResults.Add(result);
                    }
                }
            }

            if (upload)
            {
                var response = await ArticleService.UploadImage(content);

                if (response.IsSuccessStatusCode)
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    };

                    using var responseStream = await response.Content.ReadAsStreamAsync();

                    var newUploadResults = await JsonSerializer.DeserializeAsync<IList<UploadResult>>(responseStream, options);

                    if (newUploadResults is not null)
                        uploadResults = uploadResults.Concat(newUploadResults).ToList();
                }
            }

            shouldRender = true;
        }

        protected static bool FileUpload(IList<UploadResult> uploadResults, string? fileName, out UploadResult result)
        {
            result = uploadResults.SingleOrDefault(f => f.FileName == fileName) ?? new();

            if (!result.Uploaded)
                result.ErrorCode = 5;

            return result.Uploaded;
        }

        public class File
        {
            public string? Name { get; set; }
        }

    }
}
