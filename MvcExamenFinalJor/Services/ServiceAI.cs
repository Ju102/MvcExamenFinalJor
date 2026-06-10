using System.Net.Http.Headers;
using System.Text;

namespace MvcExamenFinalJor.Services
{
    public class ServiceAI
    {
        private readonly MediaTypeWithQualityHeaderValue header;
        private readonly string apiUrl;

        public ServiceAI(IConfiguration config)
        {
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
            this.apiUrl = "https://wbnk51yy53.execute-api.us-east-1.amazonaws.com/prod/";
        }

        public async Task<string> GetRespuestaAsync(string pregunta)
        {
            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(pregunta, Encoding.UTF8, "text/plain");

                HttpResponseMessage response = await client.PostAsync(this.apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    string respuestaIA = await response.Content.ReadAsStringAsync();

                    return respuestaIA;
                }
                else
                {
                    return "Error al obtener respuesta de la IA.";
                }
            }
        }

    }
}
