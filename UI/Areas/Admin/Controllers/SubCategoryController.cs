using DataAccess.Entities;
using Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Admin.Controllers
{
    public class SubCategoryController : Controller
    {
        CategoryService categoryService = new CategoryService();
        SubCategoryService subCategoryService = new SubCategoryService();
        // GET: Admin/SubCategory
        public ActionResult Index()
        {
            return View(subCategoryService.GetActive());
        }

        // GET: Admin/SubCategory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/SubCategory/Create
        public ActionResult Create()
        {
            //ViewBag.Categories = new SelectList(categoryService.GetActive(), "ID", "CategoryName");
            ViewBag.Categories = categoryService.GetActive();
            return View();
        }

        // POST: Admin/SubCategory/Create
        [HttpPost]
        public ActionResult Create(SubCategory subCategory)
        {
            try
            {
                subCategoryService.Add(subCategory);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/SubCategory/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/SubCategory/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/SubCategory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/SubCategory/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
