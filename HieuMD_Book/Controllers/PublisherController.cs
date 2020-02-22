using BookStoreManagementCodeFirst;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HieuMD_Book.Controllers
{
    public class PublisherController : Controller
    {
        Iservices<Publisher> _publisherservice;
        public PublisherController(Iservices<Publisher> publisherservice)
        {
            _publisherservice = publisherservice;
        } 
        // GET: Publisher
        public ActionResult Index()
        {
            var publisher=_publisherservice.GetAll();
            return View(publisher);
        }

        // GET: Publisher/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Publisher/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public JsonResult AddPublisher(Publisher pub)
        {

            string responseText = "";
            bool status = false;
            try
            {
                _publisherservice.Add(pub);
                status = true;
            }
            catch (Exception ex)
            {
                responseText = ex.Message;
            }
            return Json(new { status = status, data = pub, responseText = responseText });
        }



        // POST: Publisher/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var Pub = new Publisher()
                {
                    // TODO: Add insert logic here
                   Name  = collection["Name"],
                   Description = collection["Description"],
                };
                _publisherservice.Add(Pub);
                return RedirectToAction("Index");
                // TODO: Add insert logic here             
            }
            catch
            {
                return View();
            }
        }

        // GET: Publisher/Edit/5
        public ActionResult Edit(int id)
        {
           var getById= _publisherservice.GetByID(id);
            return View("Edit",getById);
        }

        // POST: Publisher/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Publisher pub)
        {
            pub.PubId = id;
            _publisherservice.Update(pub);
            return RedirectToAction("Index");
        }

       
       
        public ActionResult Delete(int id)
        {
            _publisherservice.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
