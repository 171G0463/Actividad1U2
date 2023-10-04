using Actividad1U2.Models.Entities;

namespace Actividad1U2.Models.ViewModels
{
    public class EspeciesViewModel
    {
        public int Id { get; set; }
        public string NombreEspecie { get; set; } = null!;
        public ICollection<Especies> Lista { get; set; } = null!;
    }
}