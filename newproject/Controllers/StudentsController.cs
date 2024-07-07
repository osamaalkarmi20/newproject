using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using newproject.Models;
using newproject.data;
using newproject.Models.Interface;
using System.Net;

namespace newproject.Controllers
{
    public class StudentsController : Controller
    {
      
        private readonly IStudent _student;
       public StudentsController(IStudent student)
        {
         
            _student = student;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
           var stud= await _student.GetAll();
            return View(stud);
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var student =  await _student.Get(id);

                return View(student);
            }
           
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,email,CreatedDate")] Student student)
        {if (ModelState.IsValid)
            {
                var studentCreated = await _student.Create(student);

                return RedirectToAction(nameof(Index));
            }else return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
           var  student=  await   _student.Get(id);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,email,CreatedDate")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               
                   await _student.Update(student);
                
                
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

     
        public async Task<IActionResult> Delete(int id)
        {var student= await _student.Get(id);

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _student.Get(id);
            var studentdeleted = await _student.Delete(id);
            return RedirectToAction(nameof(Index));
        }

   
    }
}
