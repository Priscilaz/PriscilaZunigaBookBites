using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriscilaZunigaAppBookBites.Models
{
    
    
    public class PZLibro
    {
        public int pzlibroId { get; set; }
        public string? pztitulo { get; set; }
        public string? pzautor { get; set; }
        public int? pzvolumen { get; set; }
        public double? pzprecio { get; set; }
        public string? pznombre { get; set; }
        public List<object>? pzcopia { get; set; }
    }


}
