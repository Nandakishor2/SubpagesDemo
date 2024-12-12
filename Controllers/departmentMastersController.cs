using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SubpagesMVCArchitecture.Data;
using SubpagesMVCArchitecture.Models;

namespace SubpagesMVCArchitecture.Controllers
{
    public class departmentMastersController : Controller
    {
        private readonly EmployeeDBContext _context;

        public departmentMastersController(EmployeeDBContext context)
        {
            _context = context;
        }

        // GET: departmentMasters
        public async Task<IActionResult> Index()
        {
            return View(await _context.departmentMaster.ToListAsync());
        }

        // GET: departmentMasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentMaster = await _context.departmentMaster
                .FirstOrDefaultAsync(m => m.id == id);
            if (departmentMaster == null)
            {
                return NotFound();
            }

            return View(departmentMaster);
        }

        // GET: departmentMasters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: departmentMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name")] departmentMaster departmentMaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departmentMaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departmentMaster);
        }

        // GET: departmentMasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentMaster = await _context.departmentMaster.FindAsync(id);
            if (departmentMaster == null)
            {
                return NotFound();
            }
            return View(departmentMaster);
        }

        // POST: departmentMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name")] departmentMaster departmentMaster)
        {
            if (id != departmentMaster.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departmentMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!departmentMasterExists(departmentMaster.id))
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
            return View(departmentMaster);
        }

        // GET: departmentMasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentMaster = await _context.departmentMaster
                .FirstOrDefaultAsync(m => m.id == id);
            if (departmentMaster == null)
            {
                return NotFound();
            }

            return View(departmentMaster);
        }

        // POST: departmentMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departmentMaster = await _context.departmentMaster.FindAsync(id);
            if (departmentMaster != null)
            {
                _context.departmentMaster.Remove(departmentMaster);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool departmentMasterExists(int id)
        {
            return _context.departmentMaster.Any(e => e.id == id);
        }
    }
}
