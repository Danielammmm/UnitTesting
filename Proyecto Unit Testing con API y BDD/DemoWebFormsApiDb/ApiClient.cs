using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static DemoWebFormsApiDb.Default;

namespace DemoWebFormsApiDb
{
    public interface IApiClient
    {
        Task<ApiResponse> GetSampleDataById(int id);
    }

    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:44368/") // Cambia este puerto si es necesario
            };
        }

        public async Task<ApiResponse> GetSampleDataById(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/sample/data/{id}");
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);
            }
            catch (Exception ex)
            {
                // Manejo de errores (puedes registrar los errores aquí si tienes un sistema de logs)
                throw new ApplicationException($"Error al obtener datos de la API para el ID {id}: {ex.Message}");
            }
        }
    }

    public class ApiResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
