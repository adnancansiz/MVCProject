using API.Models;
using DataAccess.Entities;
using Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class CategorysController : ApiController
    {
        CategoryService ct = new CategoryService();

        public IHttpActionResult GetActive()
        {
            List<CategoryVM> categoryVMs = ct.GetActive().Select(x => new CategoryVM
            {
                CategoryName = x.CategoryName,
                Description = x.Description
            }).ToList();
            return Ok(categoryVMs);
        }

        public IHttpActionResult PostCategory(CategoryVM categoryVM)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category()
                {
                    CategoryName = categoryVM.CategoryName,
                    Description = categoryVM.Description,

                };
                ct.Add(category);
                return Ok(category);
            }
            return BadRequest();
        }

        public IHttpActionResult DeleteCategory(Guid id)
        {
            //Todo : Remove Repostorye taşınacak.

            var delete = ct.GetById(id);
            if (delete != null)
            {
                delete.Status = Core.Enums.Status.Deleted;
                ct.Update(delete);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        public IHttpActionResult PutCategory(CategoryUpdateVM categoryUpdateVM)
        {
            try
            {
                var category = ct.GetById(categoryUpdateVM.CategoryID);
                if (category != null)
                {
                    category.CategoryName = categoryUpdateVM.CategoryName;
                    category.Description = categoryUpdateVM.Description;
                    ct.Update(category);
                    return Ok("Güncelleme başarılı");
                }
                return BadRequest("Aranan Id bulunamadı");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }
    }
}
