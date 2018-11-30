using CrudEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudEntityFramework.Interfaz
{
    public interface IEscuela
    {
        List<AlumnoModel> CargarAlumnos();

        List<MateriaModel> CargarMaterias();

        List<CalificacionModel> Consultar();
        bool Eliminar(int id);
        bool Agregar(CalificacionAlumno model);
        bool Actualizar(CalificacionAlumno model);
        CalificacionAlumno Recuperar(CalificacionAlumno model);
    }
}
