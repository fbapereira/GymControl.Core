using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GymControl.Models
{
    public class GC_Modalidade
    {
        public Int32 Id { get; set; }

        [Required]
        public String Nome { get; set; }

        public int AcademiaId { get; set; }

    }
}