using BookStoreManagementCodeFirst;
using Services;
using System;
using System.Transactions;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HieuMD_Book.Controllers
{
    public class CartItemController : Controller
    {

        private readonly Iservices<Book> _bookServices;
        private readonly Iservices<Order> _OrderServices;
        private readonly Iservices<OrderDetail> _OrderDetailServices;

        public CartItemController(Iservices<Book> bookServices, Iservices<Order> OrderServices, Iservices<OrderDetail> OrderDetailServices)
        {
            _bookServices = bookServices;
            _OrderServices = OrderServices;
            _OrderDetailServices = OrderDetailServices;
        }
        private const string CartSesssion = "CartSession";


        // GET: CartIem

        public ActionResult Index()
        {
            var cart = Session[CartSesssion];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }





        public ActionResult AddItem(int BookId, int Quantity)
        {
            var getByid = _bookServices.GetByID(BookId);
            var cart = Session[CartSesssion];
            Book book = new Book();
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.book.BookId == BookId))
                {

                    foreach (var item in list)
                    {
                        if (item.book.BookId == BookId)
                        {

                            if (item.book.Quantity >1)
                            {
                                item.Quantity += Quantity;
                                item.book.Quantity -= item.Quantity;
                            }
                            else
                            {
                                book.IsActive = false;
                                TempData["Quantity"] = $"Sách {item.book.BookName}   trong kho đã hết !!!!";
                                
                            }
                        }
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.book = getByid;
                    item.Quantity += Quantity;
                    //if (book.Quantity == 0)
                    //{
                    //    ViewBag.Quantity = "Sách trong kho đã hết";
                    //}
                    //else
                    //{
                    //    item.Quantity = Quantity;
                    //}

                    list.Add(item);

                }
                Session[CartSesssion] = list;

            }
            else
            {
                var list = new List<CartItem>();
                var item = new CartItem();
                item.book = getByid;
                item.Quantity = Quantity;
                list.Add(item);


                Session[CartSesssion] = list;
            }

            return RedirectToAction("Index");
        }

      
        public ActionResult SuaSoLuong(int BookId)
        {
            // tìm carditem muon sua
            List<CartItem> giohang = Session[CartSesssion] as List<CartItem>;
            CartItem itemSua = giohang.FirstOrDefault(m => m.book.BookId == BookId);
            if (itemSua != null && itemSua.Quantity > 1)
            {
                itemSua.Quantity -= 1;
                itemSua.book.Quantity += 1;
            }
            return Json(true, JsonRequestBehavior.AllowGet);

        }
        public ActionResult ThemSoLuong(int BookId)
        {
            var status = true;
            // tìm carditem muon sua
            List<CartItem> giohang = Session[CartSesssion] as List<CartItem>;
            CartItem itemSua = giohang.FirstOrDefault(m => m.book.BookId == BookId);

            if (itemSua.book.Quantity >1)
            {
                itemSua.Quantity += 1;
                itemSua.book.Quantity -= 1;
                
            }
            else
            {
                status = false;
            }

            return Json(status, JsonRequestBehavior.AllowGet);

        }


        public ActionResult XoaKhoiGio(int BookId)
        {
            List<CartItem> giohang = Session[CartSesssion] as List<CartItem>;
            CartItem itemXoa = giohang.FirstOrDefault(x => x.book.BookId == BookId);
            if (itemXoa != null)
            {
                giohang.Remove(itemXoa);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Pay()
        {

            if (Session["UserName"] == null)
            {
                return RedirectToAction("Index", "Login");
            }


            var cart = Session[CartSesssion];
            var list = new List<CartItem>();
            list = (List<CartItem>)cart;
            if (list == null || list.Count == 0)
            {
                TempData["Name"] = "Mời bạn mua hàng";
                return RedirectToAction("Index", "CartItem");
            }




            return View();
        }
        [HttpPost]
        public ActionResult Pay(Order order)
        {
            try
            {


                using (TransactionScope tran = new TransactionScope())
                {
                    Book book = new Book();
                 
                    order.Username = ((Users)Session["UserName"]).UserName;
                    int orderId = _OrderServices.Add(order);
                    var cart = Session[CartSesssion];
                    
                    var list = (List<CartItem>)cart;
                    foreach (var item in list)
                    {
                     OrderDetail ord = new OrderDetail();
                        book.BookId = item.book.BookId;
                        ord.OrderID = orderId;
                        ord.BookID = item.book.BookId;
                        ord.Discount = 0;
                                 
                        ord.Quantity = item.Quantity;

                        ord.UnitPrice = item.book.Price;

                        item.book.Quantity = (item.book.Quantity - item.Quantity) + 1;

                        if (item.book.Quantity <= 0)
                        {
                            item.book.IsActive = false;
                        }
                       
                        _OrderDetailServices.Add(ord);

                        _bookServices.Update(item.book);
                        





                    }
                    TempData["MessageBox"] = "Bạn đã đặt hàng thành công!! Thanks You";
                    tran.Complete();
                    Session[CartSesssion] = null;

                }
            }

            catch (Exception ex)
            {


            }
            return RedirectToAction("Index", "ViewHome");

        }




    }
}