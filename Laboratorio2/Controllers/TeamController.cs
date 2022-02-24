using CsvHelper;
using Lab2;
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
    public class TeamController : Controller
    {
        // GET: TeamController
        public ActionResult Index()
        {
            return View(Data.Instance.TeamList);
        }

        [HttpGet]
        public IActionResult Index(List<TeamModel> teams = null)
        {
            teams = teams == null ? new List<TeamModel>() : teams;
            return View(teams);
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

            var teams = this.GetTeamList(file.FileName);

            return Index(teams);
        }
        private List<TeamModel> GetTeamList(string fileName)
        {
            List<TeamModel> teams = new List<TeamModel>();
            #region Read CSV
            var path = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\files"}" + "\\" + fileName;
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    var team = csv.GetRecord<TeamModel>();
                    teams.Add(team);
                }
            }
            #endregion

            #region Create CSV
            path = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\FilesTo"}";
            using (var write = new StreamWriter(path + "\\NewFile.csv"))
            using (var csv = new CsvWriter(write, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(teams);
            }
            #endregion
            return teams;
        }

        // GET: TeamController/Details/5
        public ActionResult Details(string id)
        {
            var teams = Data.Instance.TeamList.Find(persona => persona.Name == id);
            return View(teams);
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
                //var teams = Lab2.GenericList<TeamModel>.Add(informacion);
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
            var teams = Data.Instance.TeamList.Find(Equipo => Equipo.Name  == id);
            return View(teams);
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
        public ActionResult Delete(string id)
        {
            var teams = Data.Instance.TeamList.Find(Team => Team.Name == id);
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

    //Delegado


    delegate void MyDelegate();

    MyDelegate NDele = new MyDelegate(Equipos.Busqueda);
    //Ordenamiento 

    class Equipos
    {
        public static void Busqueda ()
        {
            Console.WriteLine("Estos son todos los equipos que fueron ingresados en el archivo cvs");
        }
    }

}
