using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudEntityFramework.Models
{
    public class CalificacionesModel
    {
        public short IdAlumno { get; set; }
        public string NombreAlumno { get; set; }
        public string App { get; set; }
        public string Apm { get; set; }
        public short IdCarrera { get; set; }
        public string NombreCarrera { get; set; }
        public short IdMateria { get; set; }
        public string NombreMateria { get; set; }

    }
}