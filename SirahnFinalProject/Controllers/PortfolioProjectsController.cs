using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SirahnFinalProject.Models;

namespace SirahnFinalProject.Controllers
{
    public class PortfolioProjectsController : Controller
    {
        private ItsMeSirahnEntities db = new ItsMeSirahnEntities();

        // GET: PortfolioProjects
        public ActionResult Index()
        {
            return View(db.PortfolioProjects.ToList());
        }

        // GET: PortfolioProjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PortfolioProject portfolioProject = db.PortfolioProjects.Find(id);
            if (portfolioProject == null)
            {
                return HttpNotFound();
            }
            return View(portfolioProject);
        }

        // GET: PortfolioProjects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PortfolioProjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProjectID,ProjectName,ProjectDescription,ProjectLink,Screenshot")] PortfolioProject portfolioProject)
        {
            if (ModelState.IsValid)
            {
                db.PortfolioProjects.Add(portfolioProject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(portfolioProject);
        }

        // GET: PortfolioProjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PortfolioProject portfolioProject = db.PortfolioProjects.Find(id);
            if (portfolioProject == null)
            {
                return HttpNotFound();
            }
            return View(portfolioProject);
        }

        // POST: PortfolioProjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProjectID,ProjectName,ProjectDescription,ProjectLink,Screenshot")] PortfolioProject portfolioProject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(portfolioProject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(portfolioProject);
        }

        // GET: PortfolioProjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PortfolioProject portfolioProject = db.PortfolioProjects.Find(id);
            if (portfolioProject == null)
            {
                return HttpNotFound();
            }
            return View(portfolioProject);
        }

        // POST: PortfolioProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PortfolioProject portfolioProject = db.PortfolioProjects.Find(id);
            db.PortfolioProjects.Remove(portfolioProject);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
