using LosSimson.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LosSimson.Controllers
{
    public class HomeController : Controller
    {
        public simsonContext Context { get; }
        public HomeController(simsonContext context)
        {
            Context=context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("Temporadas")]
        public IActionResult Temporadas()
        {
            var t = Context.Temporada.OrderBy(x => x.Numero);
            return View(t);
        }
        [Route("Episodios/{id}")]
        public IActionResult Episodios(int id)
        {
            var t = Context.Episodios.Include(x=>x.IdTemporadaNavigation).Where(x => x.IdTemporada == id);
            return View(t);
        }
        [Route("Episodio/{id}")]
        public IActionResult Episodio(int id)
        {
            var t = Context.Episodios.FirstOrDefault(x => x.Id == id);
            if (t==null)
            {
                return RedirectToAction("Index");
            }
            return View(t);
        }
    }
}
