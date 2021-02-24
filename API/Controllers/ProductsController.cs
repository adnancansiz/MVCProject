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
    public class ProductsController : ApiController
    {
        ProductService productService = new ProductService();

        public IHttpActionResult GetActive()
        {
            List<ProductsListVM> productsListVMs = productService.GetActive().Select(x => new ProductsListVM
            {
                ImagePath = x.ImagePath,
                ProductName = x.ProductName,
                UnitPrice = x.UnitPrice,
                UnitsInStock = x.UnitsInStock

            }).ToList();
            return Ok(productsListVMs);
        }

        public HttpResponseMessage DeleteProduct(Guid id)
        {
            try
            {
                var product = productService.GetById(id);
                productService.Remove(id);
                return Request.CreateResponse(HttpStatusCode.OK, GetActive());
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }

        public HttpResponseMessage PostProduct([FromBody] ProductsCrudVM productsCrudVM)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product
                {
                    ProductName = productsCrudVM.ProductName,
                    UnitPrice = productsCrudVM.UnitPrice,
                    UnitsInStock = productsCrudVM.UnitsInStock,
                    ImagePath = productsCrudVM.ImagePath,
                    MasterId = productsCrudVM.MasterId,
                    SubCategoryId = productsCrudVM.SubCategoryId
                };
                productService.Add(product);
                return Request.CreateResponse(HttpStatusCode.Created, product);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Doldurulması Zorunlu Alanlar Mevcut.");
            }
        }

        public IHttpActionResult PutProduct(ProductsCrudVM productsCrudVM)
        {
            try
            {
                var updated = productService.GetById(productsCrudVM.ID);
                updated.ProductName = productsCrudVM.ProductName;
                updated.UnitPrice = productsCrudVM.UnitPrice;
                updated.UnitsInStock = productsCrudVM.UnitsInStock;
                updated.SubCategoryId = productsCrudVM.SubCategoryId;
                updated.MasterId = productsCrudVM.MasterId;
                updated.ImagePath = productsCrudVM.ImagePath;
                productService.Update(updated);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
