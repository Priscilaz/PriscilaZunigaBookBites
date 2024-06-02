using System.ComponentModel.DataAnnotations;

namespace PriscilaZunigaWebBookBites.Models
{
    public class PZLibro
    {
        public int PZLibroID { get; set; }


        [Required(ErrorMessage = "No puede dejar el campo Título vacío")]
        [Display(Name = "Título")]
        public string? PZTitulo { get; set; }

        [Required(ErrorMessage = "No puede dejar el campo Autor vacío")]
        [Display(Name = "Autor")]
        public string? PZAutor { get; set; }

        [Required(ErrorMessage = "No puede dejar el campo Volumen vacío")]
        [Display(Name = "Volumen")]
        public int PZVolumen { get; set; }

        [Required(ErrorMessage = "No puede dejar el campo Precio vacío")]
        [Range(0.01, 9999.99)]
        [Display(Name = "Precio")]
        public float PZPrecio { get; set; }


        [Required(ErrorMessage= "No puede dejar el campo Descripción vacío")]
        [Display(Name = "Descripción del Libro")]
        public string? PZNombre { get; set; }

        

        public List<PZCopia>? PZCopia { get; set; }

    }
}
