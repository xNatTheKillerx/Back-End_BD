
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Back_End_BD.Models
{
    public class AlumnoDbContext:DbContext
    {
        private const string ConnectionString = "DefaultConnection";
        public AlumnoDbContext():base(ConnectionString)
        {

        }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Profesor> Profesores { get; set; }

    }
}