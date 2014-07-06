using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using DemoBlog.Application;
using DemoBlog.Models;

namespace DemoBlog.Controllers
{
    public class HomeController : RavenController
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            var entries = Session.Query<Entry>().ToList();
            
            return View(entries);
        }
        
        public ActionResult ViewEntry(string slug)
        {
            var entry = Session.Query<Entry>().FirstOrDefault(e => e.Slug == slug);
            if (entry == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            entry.Comments = entry.Comments ?? new List<Comment>();
            entry.Tags = entry.Tags ?? new List<string>();
            
            return View(entry);
        }

        public ActionResult NewEntry()
        {
            var entry = new Entry();
            
            entry.Comments = entry.Comments ?? new List<Comment>();
            entry.Tags = entry.Tags ?? new List<string>();

            return View(entry);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult NewEntry(Entry entrytoSave)
        {
            if (entrytoSave == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var newslug = Repository.CreateSlug(entrytoSave.Title);
            if (Session.Query<Entry>().Any(e => e.Slug == newslug))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var entry = new Entry
            {
                CreationDate=DateTime.Now,
                PublishDate = DateTime.Now,
                Author = "csmacnz",
                Slug = newslug,
                Comments = new List<Comment>(),
                Tags = new List<string>(),
                Title = entrytoSave.Title,
                Content = entrytoSave.Content
            };
            
            Session.Store(entry);

            return RedirectToAction("ViewEntry", new { slug = newslug});
        }

        public ActionResult EditEntry(string slug)
        {
            var entry = Session.Query<Entry>().FirstOrDefault(e => e.Slug == slug);
            if (entry == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            entry.Comments = entry.Comments ?? new List<Comment>();
            entry.Tags = entry.Tags ?? new List<string>();

            return View(entry);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditEntry(string slug, Entry entrytoSave)
        {
            if (entrytoSave == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var entry = Session.Query<Entry>().FirstOrDefault(e => e.Slug == slug);
            if (entry == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            entry.CreationDate = entry.CreationDate > DateTime.MinValue ? entry.CreationDate : DateTime.Now;
            entry.PublishDate = entry.PublishDate ?? DateTime.Now;
            entry.Author = entry.Author ?? "csmacnz";
            entry.Comments = entry.Comments ?? new List<Comment>();
            entry.Tags = entry.Tags ?? new List<string>();
            entry.Title = entrytoSave.Title;
            entry.Content = entrytoSave.Content;

            return RedirectToAction("ViewEntry", new {slug = slug});
        }
        
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}