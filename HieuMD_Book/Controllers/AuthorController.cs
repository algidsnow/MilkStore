using BookStoreManagementCodeFirst;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HieuMD_Book.Controllers
{
    public class AuthorController : Controller
    {
        private readonly Iservices<Author> _authorService;
        private readonly Iservices<BookService> _BookService;

        public AuthorController(Iservices<Author> authorServices)
        {
            _authorService = authorServices;
        }
        public ActionResult Index()
        {
            var author = _authorService.GetAll();
            return View(author);
           
        }
        [HttpPost]
        public JsonResult AddAuthor(Author author)
        {

            string responseText = "";
            bool status = false;
            try
            {
                _authorService.Add(author);
                status = true;
            }
            catch (Exception ex)
            {
                responseText = ex.Message;
            }
            return Json(new { status = status, data = author, responseText = responseText });
        }

        // GET: Auther/Details/5
       
        // GET: Auther/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Auther/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            
            try
            {
                var author = new Author
                {
                    AuthorName = collection["AuthorName"],
                    History = collection["History"],
                };
                _authorService.Add(author);
                
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Auther/Edit/5
        public ActionResult Edit(int id)
        {
          var getById=  _authorService.GetByID(id);
            return View(getById);
        }

        // POST: Auther/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,Author author)
        {
            author.AuthorId = id;
            _authorService.Update(author);
            return RedirectToAction("Index");
        }

      
      
        public ActionResult Delete(int Id)
        {
            _authorService.Delete(Id);
            return RedirectToAction("Index");
        }


        



        public JsonResult Add(Author emp)
        {

            return Json(_authorService.Add(emp), JsonRequestBehavior.AllowGet);
        }
    }
}
