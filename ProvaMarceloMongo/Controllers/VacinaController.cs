using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using ProvaMarceloMongo.Models;

namespace ProvaMarceloMongo.Controllers
{
    public class VacinaController : Controller
    {
        private readonly MongoDBContext _mongoDBContext =
            new MongoDBContext();
        public IActionResult Index()
        {
            return View(_mongoDBContext.Vacinas.Find(s => true)
                   .ToList());
        }
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Vacina vacina)
        {
            if (ModelState.IsValid)
            {
                _mongoDBContext.Vacinas.InsertOne(vacina);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(string Id)
        {
            var vacinaDel = _mongoDBContext.Vacinas
                .Find(s => s.Id == ObjectId.Parse(Id)).FirstOrDefault();
            return View(vacinaDel);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(string Id)
        {
            var vacinaDel = _mongoDBContext.Vacinas
                .DeleteOne(s => s.Id == ObjectId.Parse(Id));
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string Id)
        {
            var serv = _mongoDBContext.Vacinas.Find(s => s.Id == ObjectId.Parse(Id)).FirstOrDefault();
            return View(serv);
        }

        [HttpPost]
        public ActionResult Edit(Vacina vacina, string id)
        {
            if (ModelState.IsValid)
            {
                vacina.Id = ObjectId.Parse(id);
                var filter = new BsonDocument("_id", ObjectId.Parse(id));
                _mongoDBContext.Vacinas.ReplaceOne(filter, vacina);

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}