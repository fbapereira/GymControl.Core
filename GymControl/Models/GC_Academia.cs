using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GymControl.Models
{
    public class GC_Academia
    {

        public Int32 Id { get; set; }

        [Required]
        public String Nome { get; set; }

        [Required]
        public String Email { get; set; }

        [Required]
        public String Token { get; set; }

        public ICollection<GC_Usuario> Usuarios { get; set; }
        public ICollection<GC_Modalidade> Modalidades { get; set; }

    }
}