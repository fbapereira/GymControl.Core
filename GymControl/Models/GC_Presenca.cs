using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GymControl.Models
{
    public class GC_Presenca
    {
        public Int32 Id { get; set; }

        [Required]
        public GC_Aula Aula { get; set; }

        [Required]
        public GC_Usuario Usuario { get; set; }

    }
}