using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymControl.Models
{
    public class GC_PagSeguroNotification
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public Nullable<bool> IsProcessed { get; set; }
        public string Address { get; set; }
    }
}