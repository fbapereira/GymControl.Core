using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GymControl.Models
{
    public class GC_Mensalidade
    {
        public Int32 Id { get; set; }

        [Required]
        public Decimal Valor { get; set; }

        [Required]
        public DateTime Vencimento { get; set; }

        [Required]
        public Int32 GC_MensalidadeStatusId { get; set; }

        [Required]
        public Int32 GC_AcademiaId { get; set; }

        [Required]
        public Int32 GC_UsuarioId { get; set; }
                
    }
}