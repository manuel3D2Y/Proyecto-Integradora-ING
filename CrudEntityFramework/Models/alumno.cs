//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CrudEntityFramework.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class alumno
    {
        public short Id_A { get; set; }
        public string Nombre_alum { get; set; }
        public string App_Alum { get; set; }
        public string Apm_Alum { get; set; }
        public Nullable<short> edad_alum { get; set; }
        public string sexo_alum { get; set; }
        public Nullable<short> ID_c { get; set; }
        public Nullable<short> id_gpo { get; set; }
        public Nullable<System.DateTime> fec_nac { get; set; }
    
        public virtual Carrera Carrera { get; set; }
        public virtual grupo grupo { get; set; }
    }
}
