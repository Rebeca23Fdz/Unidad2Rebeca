using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Unidad2Act.Models.Entities;
using Unidad2Act.Models.ViewModel;

namespace Unidad2Act.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            MitologiaMexicanaContext context= new();
            IndexViewModel vm=new();

            vm.Civilizaciones = context.civilizacion
                .Select(c=>new IndexViewModel.CivilizacionModel
                {
                    Nombre=c.Nombre,
                    Descripcion=c.Descripcion?? "Sin descripción"
                }).ToList();
            
            return View(vm);
        }

        public IActionResult Civilizaciones()
        {
            MitologiaMexicanaContext context = new();
            CivilizacionesViewModel vm = new();
            vm.Civilizaciones = context.civilizacion
                .Select(c => new CivilizacionesViewModel.CivilizaModel
                {
                    Nombre = c.Nombre,
                    Descripcion = c.Descripcion ?? "Sin descripción",
                    Region = c.Region ?? "Desconocida",
                    Capital = c.Capital ?? "Desconocida",
                    Lengua = c.Lengua ?? "Desconocida",
                    PeriodoInicio = c.PeriodoInicio,
                    PeriodoFin = c.PeriodoFin,
                    Dioses = c.CivilizacionDios
                        .Select(cd => cd.IdDiosNavigation.NombreGeneral)
                        .ToList()
                }).ToList();
            return View(vm);
        }

        public IActionResult Dioses(string civilizacion)
        {
            using var context = new MitologiaMexicanaContext();

            var todasCivilizaciones = context.civilizacion
                .Select(c => c.Nombre)
                .Distinct()
                .ToList();

            var diosesQuery = context.Dioses
                .Include(d => d.CivilizacionDios)
                    .ThenInclude(cd => cd.IdCivilizacionNavigation)
                .AsQueryable();

            if (!string.IsNullOrEmpty(civilizacion))
            {
                diosesQuery = diosesQuery
                    .Where(d => d.CivilizacionDios
                        .Any(cd => cd.IdCivilizacionNavigation.Nombre == civilizacion));
            }

            var dioses = diosesQuery
                .Select(d => new DiosesViewModel.DiosModel
                {
                    Id=d.Id,
                    Nombre = d.NombreGeneral,
                    Descripcion = d.Descripcion ?? "Sin descripción",
                    Genero = d.Genero ?? "Desconocido",
                    Dominio = d.Dominio ?? "Desconocido",
                    Representacion = d.CivilizacionDios
                        .Select(cd => cd.NombreLocal)
                        .FirstOrDefault() ?? "Sin representación",
                    Civilizacion = d.CivilizacionDios
                        .Select(cd => cd.IdCivilizacionNavigation.Nombre)
                        .FirstOrDefault() ?? "Desconocida"
                }).ToList();

            var vm = new DiosesViewModel
            {
                CivilizacionSeleccionada = civilizacion ?? "",
                Civilizaciones = todasCivilizaciones,
                Dioses = dioses
            };

            return View(vm);
        }
    }
}
