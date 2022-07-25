using System;
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
   
    public class CompaniesController : Controller
    {
        private readonly MSContext _context;
        private readonly ISession session;

        public CompaniesController(MSContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            session = httpContextAccessor.HttpContext.Session;
        }

        // GET: Companies
        [NoDirectAccess]
        public async Task<IActionResult> Index()
        {
            return View(await _context.company.ToListAsync());
        }
        // GET: Companies
        [NoDirectAccess]
        public async Task<IActionResult> Index1()
        {

            return View(await _context.company.ToListAsync());
        }

        // GET: Companies/Details/5
        [NoDirectAccess]
        public async Task<IActionResult> Details(int? id)
        {
            Company c = new Company();
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.company
                .FirstOrDefaultAsync(m => m.CompanyId == id);
            if (company == null)
            {
                return NotFound();
            }
            ViewBag.CompanyId = company.CompanyId;
            HttpContext.Session.SetInt32("ApplyCompanyId",company.CompanyId);
            return View(company);
        }

        // GET: Companies/Create
        [NoDirectAccess]
        public IActionResult Create()
        {
          
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [NoDirectAccess]
        public async Task<IActionResult> Create([Bind("CompanyId,CompanyName,Domain,Role,Package,File")] Company company)
        {
            if (ModelState.IsValid)
            {
                _context.Add(company);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Index1","Companies");
            }
            return View(company);
        }

        // GET: Companies/Edit/5
        [NoDirectAccess]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.company.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [NoDirectAccess]
        public async Task<IActionResult> Edit(int id, [Bind("CompanyId,CompanyName,Domain,Role,Package,File")] Company company)
        {
            if (id != company.CompanyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(company);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.CompanyId))
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
            return View(company);
        }

        // GET: Companies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.company
                .FirstOrDefaultAsync(m => m.CompanyId == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [NoDirectAccess]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var company = await _context.company.FindAsync(id);
            _context.company.Remove(company);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyExists(int id)
        {
            return _context.company.Any(e => e.CompanyId == id);
        }
    }
}
