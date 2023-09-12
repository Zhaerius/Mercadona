using BlazorServer.BackOffice.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http.Headers;
using System.Text.Json;

namespace BlazorServer.BackOffice.Components.Upload
{
    public class FilesUploadBase: ComponentBase
    {
        protected List<IBrowserFile> _files = new();
        protected bool _shouldRender;
        protected string? _path;
        [Inject] protected ArticleService ArticleService { get; set; } = null!;
        [Inject] protected UploadState UploadState { get; set; } = null!;
        [Inject] IConfiguration Configuration { get; set; } = null!;

        protected override void OnInitialized()
        {
            _path = Configuration.GetValue<string>("PathFileImg");
        }

        protected async Task OnInputFileChange(IReadOnlyList<IBrowserFile> browserFiles)
        {
            _shouldRender = false;
            bool upload = false;
            long maxFileSize = 1024 * 500;
            using var content = new MultipartFormDataContent();

            foreach (var browserFile in browserFiles)
            {
                if (UploadState.UploadResults.SingleOrDefault(f => f.FileName == browserFile.Name) is null)
                {
                    try
                    {
                        UploadState.ClearList();
                        _files.Add(browserFile);

                        var fileContent = new StreamContent(browserFile.OpenReadStream(maxFileSize));
                        fileContent.Headers.ContentType = new MediaTypeHeaderValue(browserFile.ContentType);
                        content.Add(fileContent, browserFile.ContentType, browserFile.Name);

                        upload = true;
                    }
                    catch (Exception)
                    {
                        var result = new UploadResult()
                        {
                            FileName = browserFile.Name,
                            ErrorCode = 6,
                            Uploaded = false
                        };
                        UploadState.AddToList(result);
                    }
                }
            }

            if (upload)
            {
                var response = await ArticleService.UploadImage(content);

                if (response.IsSuccessStatusCode)
                {
                    var options = new JsonSerializerOptions{ PropertyNameCaseInsensitive = true };

                    using var responseStream = await response.Content.ReadAsStreamAsync();

                    var newUploadResults = await JsonSerializer.DeserializeAsync<IList<UploadResult>>(responseStream, options);

                    if (newUploadResults is not null)
                        UploadState.OverrideList(newUploadResults);
                }
            }

            _shouldRender = true;
        }

        protected override bool ShouldRender() => _shouldRender;
    }
}
