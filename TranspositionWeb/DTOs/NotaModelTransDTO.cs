using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TranspositionWeb.DTOs
{
    public class NotaModelTransDTO
    {
        [Required]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string notasOrigen { get; set; }
        public string notasTranspuesta { get; set; }

        public bool IsChecked { get; set; }

        public int InstrumentoOrigen { get; set; }
        public int InstrumentoDestino { get; set; }
    }
}
