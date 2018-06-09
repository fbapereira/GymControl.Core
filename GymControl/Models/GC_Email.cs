using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GymControl.Models
{
    public class GC_Email
    {
        public Int32 Id { get; set; }

        [Required]
        public String Corpo { get; set; }

        [Required]
        public String Titulo { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        public String Email { get; set; }

        [Required]
        public GC_Academia GC_AcademiaId { get; set; }

    }
}