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
    public class PlayerController : Controller
    {
        // GET: PlayerController
        public ActionResult Index()
        {
            return View(Data.Instance.PlayerList);
        }

        // GET: PlayerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PlayerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlayerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var response = PlayerModel.Save(new PlayerModel
                {
                    Team = collection["Team"],
                    Name = collection["Name"],
                    LName = collection["Last Name"],
                    Role = collection["Role"],
                    KDA = double.Parse(collection["KDA"]),
                    CreepScore = double.Parse(collection["Creepscore"]),
                });

                if (response)
                {
                    return RedirectToAction(nameof(Index));
                }
                ViewBag["Error"] = "Error while creating new element";
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: PlayerController/Edit/5
        public ActionResult Edit(string id)
        {
            var modelo = Data.Instance.PlayerList.Find(Player => Player.Name == id);
            return View(modelo);
        }

        // POST: PlayerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, IFormCollection collection)
        {
            try
            {
                var information = PlayerModel.Edit(id, new PlayerModel
                {
                    Team = collection["Team"],
                    Name = collection["Name"],
                    LName = collection["Last Name"],
                    Role = collection["Role"],
                    KDA = double.Parse(collection["KDA"]),
                    CreepScore = double.Parse(collection["Creepscore"]),
                });
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlayerController/Delete/5
        public ActionResult Delete(string id)
        {
            var model = Data.Instance.PlayerList.Find(Player => Player.Name == id);
            return View();
        }

        // POST: PlayerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                var model = PlayerModel.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
