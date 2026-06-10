using System.Text;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using MvcExamenFinalJor.Models;
using System.Threading.Tasks;

namespace MvcExamenFinalJor.Services
{
    public class ServiceEventos
    {
        private readonly string ApiUrl;
        private MediaTypeWithQualityHeaderValue header;

        public ServiceEventos(IConfiguration config)
        {
            this.ApiUrl = config.GetValue<string>("ConnectionStrings:EventosApiUrl");
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        public async Task<List<Evento>> GetEventosAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/eventos/eventos/";
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);

                HttpResponseMessage response = await client.GetAsync(this.ApiUrl + request);

                if (response.IsSuccessStatusCode)
                {
                    List<Evento> eventos = await response.Content.ReadAsAsync<List<Evento>>();
                    return eventos;
                }
                else
                {
                    return null;
                }

            }
        }

        public async Task<List<Categoria>> GetCategoriasAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/eventos/categorias/";
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);

                HttpResponseMessage response = await client.GetAsync(this.ApiUrl + request);

                if (response.IsSuccessStatusCode)
                {
                    List<Categoria> categorias = await response.Content.ReadAsAsync<List<Categoria>>();
                    return categorias;
                }
                else
                {
                    return null;
                }

            }
        }

        public async Task<List<Evento>> GetEventosByIdCategoria(int idCategoria)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = $"api/eventos/eventocategoria/{idCategoria}/";
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);

                HttpResponseMessage response = await client.GetAsync(this.ApiUrl + request);

                if (response.IsSuccessStatusCode)
                {
                    List<Evento> eventos = await response.Content.ReadAsAsync<List<Evento>>();
                    return eventos;
                }
                else
                {
                    return null;
                }

            }
        }
    }
}
