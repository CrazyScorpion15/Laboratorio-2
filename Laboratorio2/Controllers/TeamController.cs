using Laboratorio2.Helpers;
using Laboratorio2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio2.Controllers
{
    public class TeamController : Controller
    {
        // GET: TeamController
        public ActionResult Index()
        {
            return View(Data.Instance.TeamList);
        }

        // GET: TeamController/Details/5
        public ActionResult Details(string id)
        {
            var modelo = Data.Instance.TeamList.Find(persona => persona.Name == id);
            return View(modelo);
        }

        // GET: TeamController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeamController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var informacion = TeamModel.Guardar(new TeamModel
                {
                    Name = collection["Name"],
                    Coach = collection["Coach"],
                    Ligue = collection["Ligue"],
                    CreationDate = collection["CreationDate"]
                });
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TeamController/Edit/5
        public ActionResult Edit(string id)
        {
            var modelo = Data.Instance.TeamList.Find(Equipo => Equipo.Name  == id);
            return View(modelo);
        }

        // POST: TeamController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, IFormCollection collection)
        {
            try
            {
                var informacion = TeamModel.Editar(id, new TeamModel
                {
                    Name = collection["Name"],
                    Coach = collection["Coach"],
                    Ligue = collection["Ligue"],
                    CreationDate  = collection["CreationDate"]
                });
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TeamController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TeamController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
