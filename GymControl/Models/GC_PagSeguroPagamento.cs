using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymControl.Models
{
    public class GC_PagSeguroPagamento
    {
        public Int32 Id { get; set; }
        public String Code { get; set; }
        public String Link { get; set; }
        public String BarCode { get; set; }
        public String DueDate { get; set; }
        
        public Int32 GC_MensalidadeId { get; set; }
    }
}