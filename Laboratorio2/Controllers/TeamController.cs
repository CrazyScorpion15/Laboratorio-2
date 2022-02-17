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
        private object connString;

        // GET: TeamController
        public ActionResult Index()
        {
            return View(Data.Instance.TeamList);
        }

        // GET: TeamController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
                var response = TeamModel.Save(new TeamModel
                {
                    Name = "G2 ESPORTS",
                    Coach = "Dylan Falco",
                    Ligue = "LEC",
                    CreationDate = "15 October 2015",
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

        // GET: TeamController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TeamController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        //upload cvs file 

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase FileUpload)
        {
            if (FileUpload.ContentLength > 0)
            {
                // there's a file that needs our attention
                var success = db.UploadProductFile(FileUpload);

                // was everything ok?
                if (success)
                    return View("UploadSuccess");
                else
                    return View("UploadFail");
            }

            return RedirectToAction("Index", new { error = "Please upload a file..." });
        }      
        }
}
