using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaileOfFriend.BLL.Interfaces;

namespace TaileOfFriend.web.Controllers
{
    public class CategoryController:Controller
    {
        public ICategoryService categoryService;

        public CategoryController
            (ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }

        public IActionResult Categories() => View("Category" , categoryService.GetAllCategories());


        [HttpPost]
        public IActionResult AddCategory(string name)
        {
            categoryService.AddCategory(name);
            return RedirectToAction("Categories", "Admin");
        }

        public IActionResult DeleteCategory(int id)
        {
            categoryService.DeleteAsync(id);
            return RedirectToAction("Categories", "Admin");
        }

    }
}
