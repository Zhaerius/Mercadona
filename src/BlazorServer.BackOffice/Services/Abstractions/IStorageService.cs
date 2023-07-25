namespace BlazorServer.BackOffice.Services.Abstractions
{
    public interface IStorageService
    {
        Task SetToken(string token);
    }
}