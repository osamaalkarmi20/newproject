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

namespace newproject.Controllers
{
    public class CoursesController : Controller
    {
      
        private readonly ICourse _course;

        public CoursesController(ICourse course)
        {
          
            _course = course;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {

            var cor = await _course.GetAll();
            return View(cor);
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var course = await _course.Get(id);

                return View(course);
            }

        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CreatedDate")] Course course)
        {
            if (ModelState.IsValid)
            {
                var cor = await _course.Create(course);

                return RedirectToAction(nameof(Index));
            }
            else return View(course);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var Cor = await _course.Get(id);
            return View(Cor);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CreatedDate")] Course course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                await _course.Update(course);


                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var cor = await _course.Get(id);

            return View(cor);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var course = await _course.Get(id);
            var coursedeleted = await _course.Delete(id);
            return RedirectToAction(nameof(Index));
        }

      
    }
}
