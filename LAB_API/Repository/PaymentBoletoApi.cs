using LAB_API.Model;
using LAB_API.Model.Dto;
using NuGet.Protocol;
using System.Net.Http.Headers;

namespace LAB_API.Repository
{
    public class PaymentBoletoApi
    {
        private readonly HttpClient _httpClient;
        public PaymentBoletoApi(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://api-go-wash-efc9c9582687.herokuapp.com/api");
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Vf9WSyYqnwxXODjiExToZCT9ByWb3FVsjr");
        }

        public async Task<ResponseBoletoAPI> PayBoleto(string boleto, int userId)
        {
            try
            {
                var requestBody = new
                {
                    boleto = boleto,
                    user_id = userId
                }.ToJson();

                var content = new StringContent(requestBody);
                content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

                var response = await _httpClient.PostAsync(
                    _httpClient.BaseAddress + "/pay-boleto", content);


                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadFromJsonAsync<ResponseBoletoAPI>();
                    NullOrEmptyVariable<ResponseBoletoAPI>.ThrowIfNull(responseContent, "Control-M login response is null or empty");

                    return responseContent;
                }
                else
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    throw new Exception(responseContent);
                }
            }
            catch (Exception)
            {
                throw;
            }
        } 
    }
}
