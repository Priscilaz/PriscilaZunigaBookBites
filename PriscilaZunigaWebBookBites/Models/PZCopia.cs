using System.ComponentModel.DataAnnotations;

namespace PriscilaZunigaWebBookBites.Models
{
    public class PZCopia
    {
        public int PZCopiaID { get; set; }

        [Required(ErrorMessage = "No puede dejar el campo Cantidad vacío")]
        [Display(Name = "Cantidad")]

        public int PZCantidad { get; set; }

        [Required(ErrorMessage = "No puede dejar el campo Color vacío")]
        [Display(Name = "La copia es a color?")]

        public bool PZColor { get; set; }

        [Required(ErrorMessage = "No puede dejar el campo Formato vacío")]
        [Display(Name = "Tamaño")]

        public string? PZFormato { get; set; }
        [Required(ErrorMessage = "No puede dejar el campo Fecha vacío")]
        [Display(Name = "Fecha de la Copia")]
        public DateOnly PZFechaCopia { get; set; }

        public int PZLibroID {  get; set; }
        public PZLibro? PZLibro { get; set; }
    }
}
