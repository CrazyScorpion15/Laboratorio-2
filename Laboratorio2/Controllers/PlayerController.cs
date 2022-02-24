using CsvHelper;
using Laboratorio2.Helpers;
using Laboratorio2.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
namespace Laboratorio2.Controllers
{
    public class PlayerController : Controller
    {
        // GET: PlayerController
        public ActionResult Index()
        {
            return View(Data.Instance.ListaPlayers);
        }
        
        [HttpGet]
        public IActionResult Index(List<PlayerModel> modelo = null)
        {
            modelo = modelo == null ? new List<PlayerModel>() : modelo;
            return View(modelo);
        }

        [HttpPost]
        public IActionResult Index(IFormFile file, [FromServices] IHostingEnvironment hostingEnvironment)
        {
            #region Upload CSV
            string fileName = $"{hostingEnvironment.WebRootPath}\\files\\{file.FileName}";
            using (FileStream fileStream = System.IO.File.Create(fileName))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            #endregion
            var modelo = this.GetPlayerList(file.FileName);
            return Index(modelo);
        }

        private List<PlayerModel> GetPlayerList(string fileName)
        {
            List<PlayerModel> modelo = new List<PlayerModel>();

            #region Read CSV
            var path = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\files"}" + "\\" + fileName;
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    var player = csv.GetRecord<PlayerModel>();
                    modelo.Add(player);
                }
            }
            #endregion

            #region Create CSV
            path = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\FilesTo"}";
            using (var write = new StreamWriter(path + "\\NewFile.csv"))
            using (var csv = new CsvWriter(write, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(modelo);
            }
            #endregion

            return modelo;
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
