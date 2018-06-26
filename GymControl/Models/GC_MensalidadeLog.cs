using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GymControl.Models
{
    public class GC_MensalidadeLog
    {
        public Int32 Id { get; set; }

        public String Observacao { get; set; }

        public Int32 GC_UsuarioId { get; set; }

        [Required]
        public Int32 GC_MensalidadeId { get; set; }

        [Required]
        public DateTime logDate { get; set; }

        [Required]
        public Int32 GC_MensalidadeStatusId { get; set; }

        [Required]
        public Boolean IsActive { get; set; }

    }
}