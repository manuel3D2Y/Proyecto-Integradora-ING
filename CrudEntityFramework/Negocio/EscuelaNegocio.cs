using System;
using System.Collections.Generic;
using System.Linq;
using CrudEntityFramework.Excepciones;
using CrudEntityFramework.Interfaz;
using CrudEntityFramework.Models;

namespace CrudEntityFramework.Negocio
{
    public class EscuelaNegocio: IEscuela
    {
        public bool Agregar(CalificacionAlumno model)
        {
            bool respuesta = new bool();
            using (EscuelaEntities bd = new EscuelaEntities())
            {
                try
                {
                    bd.CalificacionAlumno.Add(model);
                    bd.SaveChanges();
                }
                catch (DomainException e)
                {
                    bd.Database.BeginTransaction().Rollback();
                }
            }

            return respuesta;
        }

        public List<AlumnoModel> CargarAlumnos()
        {
            List<AlumnoModel> respuesta = new List<AlumnoModel>();
            using (EscuelaEntities bd = new EscuelaEntities())
            {

                try
                {
                    respuesta = bd.alumno.AsQueryable().Select(
                                                             s => new AlumnoModel()
                                                             {
                                                                 ClaveAlumno = s.Id_A,
                                                                 NombreAlunno = s.Nombre_alum,
                                                                 App = s.App_Alum,
                                                                 Apm = s.Apm_Alum
                                                             }).ToList();

                }
                catch (Exception e)
                {
                    bd.Database.BeginTransaction().Rollback();
                }
            }

            return respuesta;
        }

        public List<MateriaModel> CargarMaterias()
        {
            List<MateriaModel> respuesta = new List<MateriaModel>();
            using (EscuelaEntities bd = new EscuelaEntities())
            {

                try
                {
                    respuesta = bd.Materia.AsQueryable().Select(
                                                               s => new MateriaModel()
                                                                    {
                                                                        IdMateria = s.ID_M,
                                                                        NombreMateria = s.Nombre_Materia
                                                                    }).ToList();

                }
                catch (Exception e)
                {
                    bd.Database.BeginTransaction().Rollback();
                }
            }

            return respuesta;
        }

        public List<CalificacionModel> Consultar()
        {
            List<CalificacionModel> respuesta = new List<CalificacionModel>();
            using (EscuelaEntities bd = new EscuelaEntities())
            {

                try
                {
                    respuesta = bd.CalificacionAlumno.AsQueryable().Select(
                                                                s => new CalificacionModel()
                                                                     {
                                                                         MiClave = s.miClave,
                                                                         IdA = s.Id_A,
                                                                         IdM = s.ID_M,
                                                                         Calif1 = s.calif_1,
                                                                         Calif2 = s.calif_2,
                                                                         Calif3 = s.calif_3,
                                                                         Calif4 = s.calif_4,
                                                                         Califf = s.calif_f,
                                                                         Ano = s.ano,
                                                                         Periodo = s.Periodo
                                                                     }).ToList();
                }
                catch (Exception e)
                {
                    bd.Database.BeginTransaction().Rollback();
                }
            }

            return respuesta;
        }

        public bool Eliminar(int id)
        {
            bool respuesta = new bool();
            using (EscuelaEntities bd = new EscuelaEntities())
            {
                try
                {
                    CalificacionAlumno pd = bd.CalificacionAlumno.FirstOrDefault(s => s.miClave == id);

                    if (pd != null)
                    {
                        bd.CalificacionAlumno.Remove(pd);
                    }
                    bd.SaveChanges();
                    respuesta = true;
                }
                catch (DomainException e)
                {
                    bd.Database.BeginTransaction().Rollback();
                }
            }

            return respuesta;
        }

        public bool Actualizar(CalificacionAlumno model)
        {
            bool respuesta = new bool();
            using (EscuelaEntities bd = new EscuelaEntities())
            {
                try
                {
                    CalificacionAlumno pd = bd.CalificacionAlumno.FirstOrDefault(s => s.miClave == model.miClave);
                    pd.Periodo = model.Periodo;
                    pd.ano = model.ano;
                    pd.calif_1 = model.calif_1;
                    pd.calif_2 = model.calif_2;
                    pd.calif_3 = model.calif_3;
                    pd.calif_4 = model.calif_4;
                    pd.calif_f = model.calif_f;

                    bd.SaveChanges();
                    respuesta = true;
                }
                catch (DomainException e)
                {
                    bd.Database.BeginTransaction().Rollback();
                }
            }

            return respuesta;
        }

        public CalificacionAlumno Recuperar(CalificacionAlumno model)
        {
            CalificacionAlumno respuesta = new CalificacionAlumno();
            using (EscuelaEntities bd = new EscuelaEntities())
            {

                try
                {
                    respuesta = bd.CalificacionAlumno.FirstOrDefault(s => s.miClave == model.miClave);
                }
                catch (Exception e)
                {
                    bd.Database.BeginTransaction().Rollback();
                }
            }

            return respuesta;
        }
    }
}