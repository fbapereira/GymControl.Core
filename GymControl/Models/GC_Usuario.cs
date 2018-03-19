using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GymControl.Models
{
    public class GC_Usuario
    {
        public Int32 Id { get; set; }

        [Required]
        public String Nome { get; set; }

        [Required]
        public String Login { get; set; }

        [Required]
        public String Senha { get; set; }

        [Required]
        public String Email { get; set; }

        [Required]
        public String CPF { get; set; }

        [DefaultValue(true)]
        public Boolean IsActive { get; set; }


        // Foreign Key
        public ICollection<GC_Academia> Academias { get; set; }

        public ICollection<GC_Modalidade> Modalidades { get; set; }

        public ICollection<GC_Mensalidade> Mensalidades { get; set; }

        public ICollection<GC_Perfil> GC_Perfils { get; set; }

    }
}