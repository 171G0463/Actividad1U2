//using Actividad1U2.Models.Entities;
using Actividad1U2.Models.Entities;
using Actividad1U2.Models.ViewModels;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Actividad1U2.Controllers
{
    public class HomeController : Controller
    {

       AnimalesContext context = new();
        public IActionResult Index()
        {
            var p = context.Clase.OrderBy(x => x.Nombre).Select(x => new IndexViewModel
            {
                ID = x.Id,
                Nombre = x.Nombre ?? "",
                Descripcion = x.Descripcion??"",
            })
            .AsEnumerable();
            return View(p);

        }

        public IActionResult Especies(string ID)
        {
            var p = context.Clase.Where(x=>x.Nombre == ID).Include(x=>x.Especies).Select(x=> new EspeciesViewModel
            {
                Id = x.Id,
                NombreEspecie = x.Nombre??"",
                Lista = x.Especies
            }).First();

            return View(p);
        }

        public IActionResult Informacion()
        {
            var j = context.Especies.Include(x=>x.Especie).Select(x => new InformeViewModel
            {
                Nombre =x.Especie,
                Clase = x.IdClaseNavigation!=null?x.IdClaseNavigation.Nombre??"":"",
                Peso =(double)(x.Peso??0),
                Tamaño = x.Tamaño ?? 0,
                Habitad=x.Habitat??"",
                descripcion=x.Observaciones??"",
            });
            return View();
        }
    }
}