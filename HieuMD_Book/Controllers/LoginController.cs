using BookStoreManagementCodeFirst;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HieuMD_Book.Controllers
{
  
    public class LoginController : Controller
    {
        IUserServices __userService;
        public LoginController(IUserServices _userService)
        {
            __userService = _userService;
        }
        public ActionResult Index()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Index(Users user)
        {
            try
            {
                var login = __userService.checkLogin(user.UserName, user.Password);

                Session["UserName"] = login;

                if (login.Role.Trim().Equals("admin"))
                {
                    TempData["Message"] = $"Welcome { user.UserName}!!!!!";
                    return RedirectToAction("Index", "Home");
                }

                else if (login.Role.Trim().Equals("employee"))

                {
                    TempData["Message"] = $"Welcome { user.UserName}!!!!!";
                    return RedirectToAction("Index", "ViewHome");
                }
                else return View();
              
                
            }
            catch (Exception ex) {
                ViewBag.error = "Bạn nhập tài khoản hoặc mật khẩu không chính xác";
                return View("index");
            }
            

              
          
    
           

            //var login1 = _userService.CheckLogin1(user.UserName, user.Password);

            //if (login != null)
            //{
                
            //    return RedirectToAction("Index", "Home");
            //}
       
                    
        }
        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(FormCollection frm)
        {
            Users user = new Users();
         
          
           
            
            user.UserName = frm["UserName"];
            user.Password = frm["PassWord"];
            user.Email = frm["Email"];
            string Again = frm["Nhaplai"];
          
            if (user.Password == Again)
            {
                __userService.Add(user);
                var login = __userService.checkLogin(user.UserName, user.Password);
                Session["UserName"] = login;
                if (login.Role.Trim().Equals("employee"))
                {
                    TempData["Message"] = $"Welcome { user.UserName}!!!!!";
                    TempData.Keep();
                    return RedirectToAction("Index", "ViewHome");
                }
             
                
            }
            else
            {
                ViewBag.Error= "Mời bạn nhập lại mật khẩu";
                return RedirectToAction("AddUser");
            }

            return RedirectToAction("Index", "ViewHome");
           
           
        }
        #region
        //[HttpPost]
        //public JsonResult LoginJs(string userName,string password)
        //{

        //    //var login = _userService.checkLogin(user.UserName, user.Password);
        //    //Session["UserName"] = login;

        //    //if (login.Role.Trim().Equals("admin"))
        //    //{
        //    //    TempData["Message"] = $"Welcome { user.UserName}!!!!!";
        //    //    return RedirectToAction("Index", "Home");
        //    //}

        //    //else if (login.Role.Trim().Equals("employee"))

        //    //{
        //    //    TempData["Message"] = $"Welcome { user.UserName}!!!!!";
        //    //    return Json(JsonRequestBehavior.AllowGet);
        //    //}

        //    var login1 = userService.CheckLogin1(userName, password);

        //    if (login1)
        //    {


        //        return Json(new {
        //            status=true,
        //            JsonRequestBehavior.AllowGet
        //        });
        //    }
        //    else return Json(new {
        //             status = true,
        //             JsonRequestBehavior.AllowGet
        //});

        //}
        #endregion
        public ActionResult LoginJS()
        {
            return View();
        }
        private const string CartSesssion = "CartSession";
       
        public ActionResult LogOut()
        {
            Session[CartSesssion] = null;

            Session["UserName"] = null;
            return RedirectToAction("Index", "ViewHome");
        }

    }
}
