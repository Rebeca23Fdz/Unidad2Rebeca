namespace Unidad2Act.Models.ViewModel
{
    public class CivilizacionesViewModel
    {
            public IEnumerable<CivilizaModel> Civilizaciones { get; set; } = null!;

            public class CivilizaModel
            {
                public string Nombre { get; set; } = null!;
                public string Descripcion { get; set; } = null!;
                public string Region { get; set; } = null!;
                public string Capital { get; set; } = null!;
                public string Lengua { get; set; } = null!;
                public int? PeriodoInicio { get; set; }
                public int? PeriodoFin { get; set; }

                public string ImagenNombre => Nombre
        .ToLower()
        .Replace(" ", "_")
        .Replace("á", "a")
        .Replace("é", "e")
        .Replace("ó", "o")
        .Replace("ú", "u")
        .Replace("ñ", "n")
        .Replace("ü", "u");
                public List<string> Dioses { get; set; } = new();
            }

            public class DiosModel
            {
                public string Nombre { get; set; } = null!;
                public string Descripcion { get; set; } = null!;
            }
        
    }
}
