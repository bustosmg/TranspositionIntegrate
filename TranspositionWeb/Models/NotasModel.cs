using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TranspositionWeb.Models
{
    public class NotasModel
    {
        [Required]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string notasCromaticas { get; set; }

        public bool IsChecked { get; set; }
    }
}
