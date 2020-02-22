using BookStoreManagementCodeFirst;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HieuMD_Book.Controllers
{
    public class CategoryController : Controller
    {
        private Iservices<Category> _cateServices;
        public CategoryController(Iservices<Category> CateServices)
        {
            _cateServices = CateServices;
        }
        // GET: Category
        public ActionResult Index()
        {
            var category = _cateServices.GetAll();
            return View(category);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public JsonResult AddModal(Category category)
        {

            string responseText = "";
            int cateId = 1;
            bool status = false;
            try
            {
                cateId = _cateServices.Add(category);
                status = true;
            }
            catch (Exception ex)
            {
                responseText = ex.Message;
            }
            return Json(new { status = status, cateID = cateId, data = category, responseText = responseText });
        }


        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var cate = new Category()
                {
                    // TODO: Add insert logic here
                    CateName = collection["CateName"],
                    Description = collection["Description"],
                };
                _cateServices.Add(cate);
                return RedirectToAction("Index");
            }

            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            var GetId = _cateServices.GetByID(id);
            return View("Create", GetId);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(Category cate, int id)
        {
            cate.CateId = id;
            _cateServices.Update(cate);
            return RedirectToAction("index");
        }

        // GET: Category/Delete/5

        // POST: Category/Delete/5

        public ActionResult Delete(int id)
        {
            _cateServices.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
