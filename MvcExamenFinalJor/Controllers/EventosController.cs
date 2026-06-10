using Microsoft.AspNetCore.Mvc;
using MvcExamenFinalJor.Models;
using MvcExamenFinalJor.Services;
using System.Threading.Tasks;

namespace MvcExamenFinalJor.Controllers
{
    public class EventosController : Controller
    {
        private readonly ServiceEventos service;
        private readonly ServiceAI AIservice;

        public EventosController(ServiceEventos service, ServiceAI AIservice)
        {
            this.service = service;
            this.AIservice = AIservice;
        }

        public async Task<IActionResult> Index()
        {
            List<Evento> eventos = await this.service.GetEventosAsync();
            return View(eventos);
        }

        public async Task<IActionResult> EventosCategoria(int? idcategoria)
        {
            List<Categoria> categorias = await this.service.GetCategoriasAsync();
            ViewData["categorias"] = categorias;

            if (!idcategoria.HasValue)
            {
                List<Evento> eventos = await this.service.GetEventosAsync();
                return View(eventos);
            }
            else
            {
                List<Evento> eventos = await this.service.GetEventosByIdCategoria(idcategoria.Value);
                return View(eventos);
            }
        }

        public IActionResult ChatIA()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChatIA(string pregunta)
        {
            string respuesta = await this.AIservice.GetRespuestaAsync(pregunta);

            ViewBag.Pregunta = pregunta;
            ViewBag.Respuesta = respuesta;

            return View(); 
        }
    }
}
