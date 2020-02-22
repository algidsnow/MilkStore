using BookStoreManagementCodeFirst;
using PagedList;
using Repository;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HieuMD_Book.Controllers
{
    public class ViewHomeController : Controller
    {
        private readonly Iservices<Book> _Bookcontex;
        private readonly IBookService _bookService;
        
        
        public ViewHomeController(Iservices<Book> Bookcontex, IBookService bookService)
        {
            _Bookcontex = Bookcontex;
            _bookService = bookService;

        }

        BookStoreDbContext db = new BookStoreDbContext();
        // GET: ViewHome
        public ActionResult Index(int page=1,int pagesize=8)
        {
            var lst = db.Books.Where(x=>x.IsActive==true).OrderBy(x=>x.CreateDate).ToPagedList(page,pagesize);
            //ViewBag.title = lst.Title;
            return View(lst);
            
        }
        public ActionResult LeftMenu()
        {
            var model = db.Authors.OrderBy(x => x.AuthorName).ToList(); ;
            return PartialView(model);
        }
        public ActionResult ListBookOfAuthor(int id, int page = 1, int pagesize = 8)
        {
            var book = _Bookcontex.GetAll().Where(x => x.AuthorId == id).ToPagedList(page,pagesize);
            return View("Index", book);
        }


        public ActionResult LeftMenu2()
        {
            var model = db.Categories.OrderBy(x => x.CateName);
            return PartialView(model);
        }
        public ActionResult ListBookOfCategory(int id, int page = 1, int pagesize = 8)
        {
            var book = _Bookcontex.GetAll().Where(x => x.CateId == id).ToPagedList(page, pagesize);
            return View("Index", book);
        }

        public ActionResult LeftMenu3()
        {
            var model = db.Publishers.OrderBy(x => x.Name);
            return PartialView(model);
        }
        public ActionResult ListBookOfPublisher(int id, int page = 1, int pagesize = 8)
        {
            var book = _Bookcontex.GetAll().Where(x => x.PubId == id).ToPagedList(page, pagesize);
            return View("Index", book);
        }

        
        public ActionResult Seach(string input,int page =1,int pagesize = 8)
        {
            var book = _bookService.Seach(input, page, pagesize);
            return View("Index", book);
        }


    }
}