﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Placement.Models;

namespace Placement.Controllers
{
    
    public class ApplicationsController : Controller
    {
        private readonly MSContext _context;

        public ApplicationsController(MSContext context)
        {
            _context = context;
        }

        // GET: Applications
        [NoDirectAccess]
        public async Task<IActionResult> Index()
        {
            var mSContext = _context.application.Include(a => a.CompanysId).Include(a => a.StudentsId);
            return View(await mSContext.ToListAsync());
        }

        // GET: Applications/Details/5
        [NoDirectAccess]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.application
                .Include(a => a.CompanysId)
                .Include(a => a.StudentsId)
                .FirstOrDefaultAsync(m => m.ApplicationID == id);
            if (application == null)
            {
                return NotFound();
            }

            return View(application);
        }

        // GET: Applications/Create
        [NoDirectAccess]
        public IActionResult Create()
        {
            //    ViewData["CompanyId"] = new SelectList(_context.company, "CompanyId", "CompanyName");
            //    ViewData["StudentId"] = new SelectList(_context.student, "StudentId", "AOI");
            //    return View();
            var result = new SelectList(from i in _context.student select i.StudentId).ToList();
            var result1 = new SelectList(from i in _context.company select i.CompanyId).ToList();
            ViewBag.StudentId = result;
            ViewBag.CompanyId = result1;
            return View();

        }

        // POST: Applications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [NoDirectAccess]
        public async Task<IActionResult> Create([Bind("ApplicationID,ApplicationDate,StudentId,CompanyId")] Application application, Application i)
        {
            ////if (ModelState.IsValid)
            //ViewBag.StudentId = application.StudentId;
            //if (_context.application.Where(i => i.StudentsId.Contains(application.StudentId)).ToList())
            //{
                _context.Add(application);
                await _context.SaveChangesAsync();
                //HttpContext.Session.SetInt32("StudentId", application.StudentId);
                return RedirectToAction("ALoginView", "Login");
            //}
            //else
            //{
            //    return View();
            //}
            
            //ViewData["CompanyId"] = new SelectList(_context.company, "CompanyId", "CompanyName", application.CompanyId);
            //ViewData["StudentId"] = new SelectList(_context.student, "StudentId", "AOI", application.StudentId);
            //return View(application);
        }

        // GET: Applications/Edit/5
        [NoDirectAccess]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.application.FindAsync(id);
            if (application == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.company, "CompanyId", "CompanyName", application.CompanyId);
            ViewData["StudentId"] = new SelectList(_context.student, "StudentId", "AOI", application.StudentId);
            return View(application);
        }

        // POST: Applications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [NoDirectAccess]
        public async Task<IActionResult> Edit(int id, [Bind("ApplicationID,ApplicationDate,StudentId,CompanyId")] Application application)
        {
            if (id != application.ApplicationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(application);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationExists(application.ApplicationID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(_context.company, "CompanyId", "CompanyName", application.CompanyId);
            ViewData["StudentId"] = new SelectList(_context.student, "StudentId", "AOI", application.StudentId);
            return View(application);
        }

        // GET: Applications/Delete/5
        [NoDirectAccess]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.application
                .Include(a => a.CompanysId)
                .Include(a => a.StudentsId)
                .FirstOrDefaultAsync(m => m.ApplicationID == id);
            if (application == null)
            {
                return NotFound();
            }

            return View(application);
        }

        // POST: Applications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [NoDirectAccess]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var application = await _context.application.FindAsync(id);
            _context.application.Remove(application);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationExists(int id)
        {
            return _context.application.Any(e => e.ApplicationID == id);
        }
    }
}
