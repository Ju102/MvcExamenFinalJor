using Microsoft.AspNetCore.Mvc;
using MvcExamenFinalJor.Models;
using MvcExamenFinalJor.Services;
using System.Threading.Tasks;

namespace MvcExamenFinalJor.Controllers
{
    public class EventosController : Controller
    {
        private readonly ServiceEventos service;

        public EventosController(ServiceEventos service)
        {
            this.service = service;
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
    }
}
