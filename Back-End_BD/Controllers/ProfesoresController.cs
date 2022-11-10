using Back_End_BD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Back_End_BD.Controllers
{
    public class ProfesoresController : Controller
    {
        public ActionResult Index()
        {
            using (AlumnoDbContext dbProfesores = new AlumnoDbContext())
            {
                //select * form alumnos;
                return View(dbProfesores.Profesores.ToList());
            }

        }

        public ActionResult Details(int? id)
        {
            using (AlumnoDbContext dbProfesores = new AlumnoDbContext())
            {
                Profesor profesor = dbProfesores.Profesores.Find(id);
                if (profesor == null)
                {
                    return HttpNotFound();
                }
                return View(profesor);
            }

        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Profesor prof)
        {
            using (AlumnoDbContext dbProfesores = new AlumnoDbContext())
            {
                dbProfesores.Profesores.Add(prof);
                dbProfesores.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            using (AlumnoDbContext dbProfesores = new AlumnoDbContext())
            {
                return View(dbProfesores.Profesores.Where(x => x.Matricula == id).FirstOrDefault());
            }
        }
        [HttpPost]
        public ActionResult Edit(Profesor prof)
        {
            using (AlumnoDbContext dbProfesores = new AlumnoDbContext())
            {
                dbProfesores.Entry(prof).State = EntityState.Modified;
                dbProfesores.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            using (AlumnoDbContext dbProfesores = new AlumnoDbContext())
            {
                return View(dbProfesores.Profesores.Where(x => x.Matricula == id).FirstOrDefault());
            }
        }
        [HttpPost]
        public ActionResult Delete(Profesor prof, int? id)
        {
            using (AlumnoDbContext dbProfesores = new AlumnoDbContext())
            {
                Profesor pf = dbProfesores.Profesores.Where(x => x.Matricula == id).FirstOrDefault();
                dbProfesores.Profesores.Remove(pf);
                dbProfesores.SaveChanges();
            }
            return RedirectToAction("Index");

        }
    }
}