namespace BlazorWasm.Components.Upload
{
    public class UploadState
    {
        public int Number { get; set; } = 0;
        public List<UploadResult> UploadResults { get; set; } = new();

        public event Action OnChange = null!;

        public void AddToList(UploadResult uploadResult)
        {
            UploadResults.Add(uploadResult);
            NotifyStateChanged();
        }

        public void OverrideList(IList<UploadResult> uploadResults)
        {
            UploadResults = (List<UploadResult>)uploadResults;
            NotifyStateChanged();
        }

        public void ClearList()
        {
            UploadResults.Clear();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
