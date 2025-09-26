using Unidad2Act.Models.Entities;

namespace Unidad2Act.Models.ViewModel
{
    public class IndexViewModel
    {
        public IEnumerable<CivilizacionModel> Civilizaciones { get; set; } // Cambiado a 'public' y tipo correcto

        public class CivilizacionModel
        {
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
        }
    }
}
