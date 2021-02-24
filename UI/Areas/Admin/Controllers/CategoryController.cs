using DataAccess.Entities;
using Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        CategoryService categoryService = new CategoryService();
        public ActionResult Index()
        {
            return View(categoryService.GetActive());
        }

        // GET: Admin/Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Category/Create
        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            {
                categoryService.Add(category);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Admin/Category/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View(categoryService.GetById(id));
        }

        // POST: Admin/Category/Edit/5
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            try
            {
                categoryService.Update(category);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Admin/Category/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View(categoryService.GetById(id));
        }

        // POST: Admin/Category/Delete/5
        [HttpPost]
        public ActionResult Delete(Category category)
        {
            try
            {
                categoryService.Remove(category.ID);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
