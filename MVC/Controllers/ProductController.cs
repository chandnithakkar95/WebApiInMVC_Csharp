using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            IEnumerable<mvcProductModel> productList;
            HttpResponseMessage response = GlobalVariable.WebApiClient.GetAsync("Product").Result;
            productList = response.Content.ReadAsAsync<IEnumerable<mvcProductModel>>().Result;
            return View(productList);
        }
        public ActionResult AddOrEdit(int id=0)
        {
            if (id == 0) {
                return View(new mvcProductModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariable.WebApiClient.GetAsync("Product/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcProductModel>().Result);
            }
            
        }
        [HttpPost]
        public ActionResult AddOrEdit(mvcProductModel productModel)
        {
            if (productModel.Id == 0)
            {

                HttpResponseMessage response = GlobalVariable.WebApiClient.PostAsJsonAsync("Product", productModel).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {

                HttpResponseMessage response = GlobalVariable.WebApiClient.PutAsJsonAsync("Product/"+productModel.Id, productModel).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {

            HttpResponseMessage response = GlobalVariable.WebApiClient.DeleteAsync("Product/"+id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}