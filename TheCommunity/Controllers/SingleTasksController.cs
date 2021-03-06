﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheCommunity;

namespace TheCommunity.Controllers
{
    public class SingleTasksController : Controller
    {
        private TheCommunityDBEntities db = new TheCommunityDBEntities();

        // GET: SingleTasks
        public ActionResult Index()
        {
            var singleTasks = db.SingleTasks.Include(s => s.Community).Include(s => s.Member);
            return View(singleTasks.ToList());
        }

        // GET: SingleTasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SingleTask singleTask = db.SingleTasks.Find(id);
            if (singleTask == null)
            {
                return HttpNotFound();
            }
            return View(singleTask);
        }

        // GET: SingleTasks/Create
        public ActionResult Create()
        {
            ViewBag.CommunityId = new SelectList(db.Communities, "Id", "Name");
            ViewBag.MemberId = new SelectList(db.Members, "Id", "FirstName");
            return View();
        }

        // POST: SingleTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,StartTime,EndTime,Description,Budget,Status,CommunityId,MemberId")] SingleTask singleTask)
        {
            if (ModelState.IsValid)
            {
                db.SingleTasks.Add(singleTask);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CommunityId = new SelectList(db.Communities, "Id", "Name", singleTask.CommunityId);
            ViewBag.MemberId = new SelectList(db.Members, "Id", "FirstName", singleTask.MemberId);
            return View(singleTask);
        }

        // GET: SingleTasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SingleTask singleTask = db.SingleTasks.Find(id);
            if (singleTask == null)
            {
                return HttpNotFound();
            }
            ViewBag.CommunityId = new SelectList(db.Communities, "Id", "Name", singleTask.CommunityId);
            ViewBag.MemberId = new SelectList(db.Members, "Id", "FirstName", singleTask.MemberId);
            return View(singleTask);
        }

        // POST: SingleTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,StartTime,EndTime,Description,Budget,Status,CommunityId,MemberId")] SingleTask singleTask)
        {
            if (ModelState.IsValid)
            {
                db.Entry(singleTask).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CommunityId = new SelectList(db.Communities, "Id", "Name", singleTask.CommunityId);
            ViewBag.MemberId = new SelectList(db.Members, "Id", "FirstName", singleTask.MemberId);
            return View(singleTask);
        }

        // GET: SingleTasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SingleTask singleTask = db.SingleTasks.Find(id);
            if (singleTask == null)
            {
                return HttpNotFound();
            }
            return View(singleTask);
        }

        // POST: SingleTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SingleTask singleTask = db.SingleTasks.Find(id);
            db.SingleTasks.Remove(singleTask);
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
