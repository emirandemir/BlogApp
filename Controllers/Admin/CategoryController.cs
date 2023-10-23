using BlogApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Controllers.Admin
{

    [Area("Admin")]
    public class CategoryController : Controller
    {

        private readonly BlogDbContext context;

        public CategoryController(BlogDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var categories = context.Categories.AsNoTracking().ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Update(int id) 
        {
            var updateCategory = this.context.Categories.AsNoTracking().SingleOrDefault(c => c.Id == id);
            return View(updateCategory);
        }
        [HttpPost]
        public IActionResult Update(Category category) 
        {
            category.SecoUrl = category.Definition;

            var updateEntity = this.context.Categories.SingleOrDefault(x => x.Id == category.Id);

            if(updateEntity != null)
            {
                updateEntity.Definition = category.Definition;
                updateEntity.SecoUrl =category.SecoUrl;
                context.Update(updateEntity);
                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
