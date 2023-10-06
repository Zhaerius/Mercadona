namespace BlazorWasm.Components.Upload
{
    public class UploadResult
    {
        public UploadResult()
        {
        }

        public UploadResult(bool uploaded, string? fileName, string? storedFileName, int errorCode)
        {
            Uploaded = uploaded;
            FileName = fileName;
            StoredFileName = storedFileName;
            ErrorCode = errorCode;
        }

        public bool Uploaded { get; set; }
        public string? FileName { get; set; }
        public string? StoredFileName { get; set; }
        public int ErrorCode { get; set; }
    }
}
