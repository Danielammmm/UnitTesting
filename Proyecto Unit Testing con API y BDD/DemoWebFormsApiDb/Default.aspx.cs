using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.Http;

namespace DemoWebFormsApiDb
{
    public partial class Default : Page
    {
        private readonly IDataRepository _dataRepository;
        public Default()
        {
            _dataRepository = new DatabaseRepository();
        }

        public class ApiClient
        {
            private readonly HttpClient _httpClient;

            public ApiClient()
            {
                _httpClient = new HttpClient
                {
                    BaseAddress = new System.Uri("http://localhost:44383/") 
                };
            }

            public async Task<string[]> GetSampleData()
            {
                var response = await _httpClient.GetAsync("api/sample/data");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<string[]>();
            }

            public async Task<string> GetSampleDataById(int id)
            {
                var response = await _httpClient.GetAsync($"api/sample/data/{id}");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }

        private readonly ApiClient _apiClient = new ApiClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDatabaseData();
            }
        }

        protected async void btnApiFetch_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(txtApiId.Text, out int id))
                {
                    string dataString = await _apiClient.GetSampleDataById(id);
                    ApiResponse data = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiResponse>(dataString);

                    if (data != null)
                    {
                        lblApiId.Text = data.Id.ToString();
                        lblApiName.Text = data.Name;
                        pnlApiData.Visible = true;
                    }
                    else
                    {
                        lblApiResult.Text = "No se encontraron datos para el ID proporcionado.";
                        pnlApiData.Visible = false;
                    }
                }
                else
                {
                    lblApiResult.Text = "Por favor, ingresa un ID válido.";
                }
            }
            catch (Exception ex)
            {
                lblApiResult.Text = $"Error al obtener datos de la API: {ex.Message}";
                pnlApiData.Visible = false;
            }
        }

        private void LoadDatabaseData()
        {
            try
            {
                DataTable users = _dataRepository.GetAllUsers();
                gvDatabaseData.DataSource = users;
                gvDatabaseData.DataBind();
            }
            catch (Exception ex)
            {
                lblApiResult.Text = $"Error al cargar datos desde la base de datos: {ex.Message}";
            }
        }
    }
}
