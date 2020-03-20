using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TranspositionWeb.Models
{
    public class AcordesModel
    {
        [Required]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string AcordesCromaticas { get; set; }
        public string acordesCromaticasMayores { get; set; }
        public string acordesCromaticasMenores { get; set; }
        public string acordesSeptimaMayor { get; set; }
        public string acordesSeptimaMenor { get; set; }
    }
}
