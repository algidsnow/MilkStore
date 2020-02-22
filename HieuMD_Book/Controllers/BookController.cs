using BookStoreManagementCodeFirst;
using PagedList;
using Repository;
using Services;
using System;
using System.Collections.Generic;

using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace HieuMD_Book.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        private readonly Iservices<Book> _bookServices;
        private readonly Iservices<Category> _categoryServices;
        private readonly Iservices<Author> _authorServices;
        private readonly Iservices<Publisher> _publisherServices;
        private readonly Iservices<Comment> _commentServices;
        public BookController(
            Iservices<Book> bookServices,
            Iservices<Comment> commentServices,
            Iservices<Category> categoryServices,
            Iservices<Author> authorServices,
            Iservices<Publisher> publisherServices
            )
        {
            _bookServices = bookServices;
            _categoryServices = categoryServices;
            _authorServices = authorServices;
            _publisherServices = publisherServices;
            _commentServices = commentServices;
        }


        public ActionResult Index(int page = 1, int pageSize = 5)
        {



            var pageList = _bookServices.ListPage(page, pageSize);
            var book = _bookServices.GetAll();
            return View(pageList);
        }
        public ActionResult Create()
        {

            ViewBag.ListCategory = _categoryServices.GetAll().ToList();
            ViewBag.ListAuthor = _authorServices.GetAll().ToList();
            ViewBag.ListPublisher = _publisherServices.GetAll().ToList();

            return View();
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(Book book)
        {
            string fileName = "";
            //try
            //{

            //    if (ImgUrl != null && ImgUrl.ContentLength > 0)

            //    {
            //        fileName = Path.GetFileName(ImgUrl.FileName);
            //        string path = Path.Combine(Server.MapPath("/Assets/images"), Path.GetFileName(ImgUrl.FileName));
            //        ImgUrl.SaveAs(path);
            //    }
            //}
            //catch (Exception ex)
            //{

            //}
            book.ImgUrl = fileName;
            _bookServices.Add(book);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int ID)
        {
            var GetId = _bookServices.GetByID(ID);
            ViewBag.ListCategory = _categoryServices.GetAll().ToList();
            ViewBag.ListAuthor = _authorServices.GetAll().ToList();
            ViewBag.ListPublisher = _publisherServices.GetAll().ToList();

            return View("Create", GetId);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(Book book, HttpPostedFileBase ImgUrl, int Id)
        {
            string fileName = "";
            try
            {

                if (ImgUrl != null && ImgUrl.ContentLength > 0)

                {
                    fileName = Path.GetFileName(ImgUrl.FileName);
                    string path = Path.Combine(Server.MapPath("/Assets/images"), Path.GetFileName(ImgUrl.FileName));
                    ImgUrl.SaveAs(path);
                    book.ImgUrl = fileName;
                }
            }
            catch (Exception ex)
            {

            }
            book.BookId = Id;
            


            _bookServices.Update(book);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            _bookServices.Delete(Id);
            return RedirectToAction("Index");
        }
        public ActionResult Detail(int Id)
        {

            var detail = _bookServices.GetByID(Id);
            return View(detail);
        }
        [HttpPost]
        public ActionResult Detail(int id, Comment comment)
        {

            var book = _bookServices.GetByID(id);
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
       


            if (book != null)

            {
                comment.BookId = book.BookId;
                comment.UserName = ((Users)Session["UserName"]).UserName;
                comment.CreatedDate = DateTime.Now;
                comment.IsActive = true;
                _commentServices.Add(comment);

            }

            return RedirectToAction("Detail");
        }

        public ActionResult ListByCategory(string cateName)
        {
            var books = _bookServices.GetAll().Where(b => b.Category.CateName.ToUpper() == cateName.ToUpper());
            return View(books);
        }


    }
}



