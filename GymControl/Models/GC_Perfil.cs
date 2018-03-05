using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GymControl.Models
{
    public class GC_Perfil
    {
        public Int32 Id { get; set; }

        [Required]
        public String Nome { get; set; }

        public GC_Academia GC_AcademiaId { get; set; }

        public ICollection<GC_Usuario> GC_Usuarios { get; set; }

    }
}