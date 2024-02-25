using Microsoft.AspNetCore.Mvc;
using WebAppMVC.Data;
using WebAppMVC.Models;

namespace WebAppMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext _db;
        public CategoryController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.categories;
            return View(objCategoryList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name==obj.DisplayOrder.ToString()) {
                ModelState.AddModelError("Name","Name and display order cannot be same");
            }
            if (ModelState.IsValid)
            {
                _db.categories.Add(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category created successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null | id == 0) {
                return NotFound();
            }
            var categoryFromDb = _db.categories.Find(id);
            if(categoryFromDb==null) {

                return NotFound();
            }
            return View(categoryFromDb);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Name and display order cannot be same");
            }
            if (ModelState.IsValid)
            {
                _db.categories.Update(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category updated successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        
        public IActionResult Delete(int? id)
        {
            if (id==null | id==0)
            { 
                return NotFound();
            }
            var categoryFromDb= _db.categories.Find(id);
            if (categoryFromDb == null) 
            { 
                return NotFound();
            }
                _db.categories.Remove(categoryFromDb);
                _db.SaveChanges();
            TempData["Success"] = "Category deleted successfully!";
                return RedirectToAction("Index");
        }
    }
}
