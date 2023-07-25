using BlazorServer.BackOffice.Services.Abstractions;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace BlazorServer.BackOffice.Services
{
    public class StorageService : IStorageService
    {
        private readonly ProtectedSessionStorage _protectedSessionStore;

        public StorageService(ProtectedSessionStorage protectedSessionStore)
        {
            _protectedSessionStore = protectedSessionStore;
        }

        public async Task SetToken(string token)
        {
            await _protectedSessionStore.SetAsync("jwt", token);
        }
    }
}
