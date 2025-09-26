namespace Unidad2Act.Models.ViewModel
{
    //public class DiosesViewModel
    //{
    //    public IEnumerable<string> Civilizaciones { get; set; } = null!;

    //    public IEnumerable<DiosModel> Dioses { get; set; }

    //    public class DiosModel
    //    {
    //        public int Id { get; set; }
    //        public string Nombre { get; set; }
    //        public string Descripcion { get; set; }
    //        public string Genero { get; set; }
    //        public string Dominio { get; set; }
    //        public string Civilizacion { get; set; }
    //        public string Representacion { get; set; }
    //    }

    //    //public List<string> Civilizaciones { get; set; }
    //}
    public class DiosesViewModel
    {
        // Nombre de la civilización seleccionada (para mostrar en el título, por ejemplo)
        public string CivilizacionSeleccionada { get; set; } = null!;

        // Lista de todas las civilizaciones disponibles (para un menú o filtro)
        public IEnumerable<string> Civilizaciones { get; set; } = new List<string>();

        // Lista de dioses filtrados por civilización
        public IEnumerable<DiosModel> Dioses { get; set; } = new List<DiosModel>();

        public class DiosModel
        {
            public int Id { get; set; }
            public string Nombre { get; set; } = null!;
            public string Descripcion { get; set; } = null!;    
            public string Civilizacion { get; set; } = null!;
            public string Genero { get; set; } = null!;
            public string Dominio { get; set; } = null!;
            public string Representacion { get; set; } = null!;
        }
    }
}
