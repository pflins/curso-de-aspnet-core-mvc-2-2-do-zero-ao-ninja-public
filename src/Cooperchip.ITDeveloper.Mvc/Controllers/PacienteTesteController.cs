﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cooperchip.ITDeveloper.Data.ORM;
using Cooperchip.ITDeveloper.Domain.Models;

namespace Cooperchip.ITDeveloper.Mvc.Controllers
{
    public class PacienteTesteController : Controller
    {
        private readonly ITDeveloperDbContext _context;

        public PacienteTesteController(ITDeveloperDbContext context)
        {
            _context = context;
        }

        // GET: PacienteTeste
        public async Task<IActionResult> Index()
        {
            return View(await _context.PacienteTeste.ToListAsync());
        }

        // GET: PacienteTeste/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacienteTeste = await _context.PacienteTeste
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pacienteTeste == null)
            {
                return NotFound();
            }

            return View(pacienteTeste);
        }

        // GET: PacienteTeste/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PacienteTeste/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,DataNascimento,Email,TipoPaciente,Sexo,Rg,Id")] PacienteTeste pacienteTeste)
        {
            if (ModelState.IsValid)
            {
                pacienteTeste.Id = Guid.NewGuid();
                _context.Add(pacienteTeste);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pacienteTeste);
        }

        // GET: PacienteTeste/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacienteTeste = await _context.PacienteTeste.FindAsync(id);
            if (pacienteTeste == null)
            {
                return NotFound();
            }
            return View(pacienteTeste);
        }

        // POST: PacienteTeste/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Nome,DataNascimento,Email,TipoPaciente,Sexo,Rg,Id")] PacienteTeste pacienteTeste)
        {
            if (id != pacienteTeste.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pacienteTeste);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacienteTesteExists(pacienteTeste.Id))
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
            return View(pacienteTeste);
        }

        // GET: PacienteTeste/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacienteTeste = await _context.PacienteTeste
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pacienteTeste == null)
            {
                return NotFound();
            }

            return View(pacienteTeste);
        }

        // POST: PacienteTeste/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var pacienteTeste = await _context.PacienteTeste.FindAsync(id);
            _context.PacienteTeste.Remove(pacienteTeste);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacienteTesteExists(Guid id)
        {
            return _context.PacienteTeste.Any(e => e.Id == id);
        }
    }
}
