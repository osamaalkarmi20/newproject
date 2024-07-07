using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using newproject.Models;
using newproject.data;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using newproject.Models.Interface;

namespace newproject.Controllers
{
    public class AddressesController : Controller
    {
        private readonly Maindbcontext _context;
        private readonly IAddress _address ;
        public AddressesController(Maindbcontext context ,IAddress address)
        {
            _context = context;
            _address = address;
        }

        // GET: Addresses
        public async Task<IActionResult> Index()
        {
            var maindbcontext = _address.GetAll();
            return View(await maindbcontext);
        }

        // GET: Addresses/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null )
            {
                return NotFound();
            }else 
{
            var address = await _address.Get(id);
                return View(address);
            }
          

           
        }

        // GET: Addresses/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id");
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Address address)
        {
                 var ad = await _address.Create(address);

                return RedirectToAction(nameof(Index));
           
           
        }

        // GET: Addresses/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var address = await _address.Get(id);
            if (address == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", address.StudentId);
            return View(address);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Address address)
        {
            if (id != address.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               
                    await _address.Update(address);

               
                
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", address.StudentId);
            return View(address);
        }

        // GET: Addresses/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

       var address = await _address.Get(id);
      
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var address = await _address.Get(id);
            if (address != null)
            {
              

                    var addressDelete = await _address.Delete(id);
                 
            }

            return RedirectToAction(nameof(Index));
        }

       
    }
}
