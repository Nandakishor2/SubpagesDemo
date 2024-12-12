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
    public class employeeMastersController : Controller
    {
        private readonly EmployeeDBContext _context;

        public employeeMastersController(EmployeeDBContext context)
        {
            _context = context;
        }

        // GET: employeeMasters
        /*
         * CreatedBy :-  NandaKishor
         * Created Date :- 27-11-2024
         * Parameters :- None
         * Purpose :- Using DbContext it gets all employees and loads upon returns to the view Index.cshtml
         * */
        public async Task<IActionResult> Index()
        {
            return View(await _context.employeeMasters.ToListAsync());
        }

        // GET: employeeMasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeMasters = await _context.employeeMasters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeMasters == null)
            {
                return NotFound();
            }

            return View(employeeMasters);
        }

        // GET: employeeMasters/Create
        public IActionResult Create()
        {
            ViewData["Departments"] = _context.departmentMaster.ToList();
            return View();
        }

        // POST: employeeMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Designatiom,Department,PhoneNumber,Email")] employeeMasters employeeMasters)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeMasters);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeMasters);
        }

        // GET: employeeMasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeMasters = await _context.employeeMasters.FindAsync(id);
            if (employeeMasters == null)
            {
                return NotFound();
            }
            return View(employeeMasters);
        }

        // POST: employeeMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Designatiom,Department,PhoneNumber,Email")] employeeMasters employeeMasters)
        {
            if (id != employeeMasters.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeMasters);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!employeeMastersExists(employeeMasters.Id))
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
            return View(employeeMasters);
        }

        // GET: employeeMasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeMasters = await _context.employeeMasters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeMasters == null)
            {
                return NotFound();
            }

            return View(employeeMasters);
        }

        // POST: employeeMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeMasters = await _context.employeeMasters.FindAsync(id);
            if (employeeMasters != null)
            {
                _context.employeeMasters.Remove(employeeMasters);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool employeeMastersExists(int id)
        {
            return _context.employeeMasters.Any(e => e.Id == id);
        }
    }
}
