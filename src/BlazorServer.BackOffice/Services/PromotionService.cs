using BlazorServer.BackOffice.Services.Abstractions;
using BlazorServer.BackOffice.Models.Promotion;

namespace BlazorServer.BackOffice.Services
{
    public class PromotionService : HttpService
    {
        private readonly HttpClient _httpClient;

        public PromotionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreatePromotion(CreatePromotionRequest createPromotion)
        {
            var response = await _httpClient.PostAsJsonAsync("promotion", createPromotion);
            return response.IsSuccessStatusCode;
        }

        public async Task<PromotionModel> GetPromotionById(Guid id)
        {
            var response = await _httpClient.GetAsync($"promotion/{id}");

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
