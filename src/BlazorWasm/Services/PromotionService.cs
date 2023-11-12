using BlazorWasm.Models.Promotion;
using BlazorWasm.Services.Abstractions;
using System.Net.Http.Json;

namespace BlazorWasm.Services
{
    public class PromotionService : HttpService
    {
        private readonly HttpClient _httpClient;

        public PromotionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Guid?> CreatePromotion(CreatePromotionRequest createPromotion)
        {
            var response = await _httpClient.PostAsJsonAsync("promotion", createPromotion);

            if (!response.IsSuccessStatusCode)
                return null;

            return await DeserializeFromHttpResponse<Guid>(response);
        }

        public async Task<PromotionModel> GetPromotionById(Guid id)
        {
            var response = await _httpClient.GetAsync($"promotion/{id}");

            if (!response.IsSuccessStatusCode)
                return null!;

            return await DeserializeFromHttpResponse<PromotionModel>(response);
        }

        public async Task<PromotionModel> GetPromotionWithArticlesById(Guid id)
        {
            var response = await _httpClient.GetAsync($"promotion/article/{id}");

            if (!response.IsSuccessStatusCode)
                return null!;

            return await DeserializeFromHttpResponse<PromotionModel>(response);
        }

        public async Task<IEnumerable<PromotionModel>> GetPromotionByStatus(bool isActive)
        {
            var response = await _httpClient.GetAsync($"promotion/{isActive}");

            if (!response.IsSuccessStatusCode || response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return Enumerable.Empty<PromotionModel>();

            return await DeserializeFromHttpResponse<IEnumerable<PromotionModel>>(response);
        }

        public async Task<bool> DeletePromotion(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"promotion/{id}");
            return response.IsSuccessStatusCode;
        }


        public async Task<bool> UpdateArticle(UpdatePromotionRequest updatePromotionRequest)
        {
            var response = await _httpClient.PutAsJsonAsync($"promotion/", updatePromotionRequest);
            return response.IsSuccessStatusCode;
        }
    }
}
