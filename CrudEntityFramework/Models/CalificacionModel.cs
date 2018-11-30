using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudEntityFramework.Models
{
    public class CalificacionModel
    {
        public int MiClave { get; set; }
        public Nullable<short> IdA { get; set; }
        public Nullable<short> IdM { get; set; }
        public Nullable<decimal> Calif1 { get; set; }
        public Nullable<decimal> Calif2 { get; set; }
        public Nullable<decimal> Calif3 { get; set; }
        public Nullable<decimal> Calif4 { get; set; }
        public Nullable<decimal> Califf { get; set; }
        public Nullable<short> Ano { get; set; }
        public Nullable<byte> Periodo { get; set; }
    }
}