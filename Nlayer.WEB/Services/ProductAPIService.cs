using Nlayer.Core.DTOs;

namespace Nlayer.WEB.Services
{
    public class ProductAPIService
    {
        private readonly HttpClient _httpClient;

        public ProductAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProductWithCategoryDto>> GetProductWithCategoryAsync()
        {
            var responce = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<ProductWithCategoryDto>>>("products/GetProductsWithCategory");
            return responce.Data;
        }
        public async Task<ProductDto> SaveAsync(ProductDto newProduct)
        {
            var response = await _httpClient.PostAsJsonAsync("products", newProduct);

            if(!response.IsSuccessStatusCode) return null;

            var responceB = await response.Content.ReadFromJsonAsync<CustomResponseDto<ProductDto>>();

            return responceB.Data;
        }
        public async Task<bool> UpdateAsync(ProductDto newProduct)
        {
            var responce = await _httpClient.PutAsJsonAsync("products", newProduct);

            return responce.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var responce = await _httpClient.DeleteAsync($"products/{id}");

            return responce.IsSuccessStatusCode;
        }
        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var reponse = await _httpClient.GetFromJsonAsync<CustomResponseDto<ProductDto>>($"products/{id}");

            return reponse.Data;
        }
    }
}
