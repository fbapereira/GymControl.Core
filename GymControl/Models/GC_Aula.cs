using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace GymControl.Models
{
    public class GC_Aula
    {
        public Int32 Id { get; set; }

        [Required]
        public String Nome { get; set; }

        [Required]
        public DateTime Inicio { get; set; }

        [Required]
        public DateTime Fim { get; set; }

        [Required]
        public Int32 GC_ModalidadeId { get; set; }

    }
}