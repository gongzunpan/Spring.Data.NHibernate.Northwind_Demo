using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spring.Northwind.Dao;
using Spring.Northwind.Domain;
namespace Spring.Northwind.MvcApp.Controllers
{
    public class HomeController : Controller
    {
        private ICustomerDao customerDao;
        public ICustomerDao CustomerDao
        {
            set { this.customerDao = value; }
        }
        public ActionResult Index()
        {
            IList<Customer> list = this.customerDao.GetAll();
            ViewBag.Message = "spring.net IOC 测试 customerDao.GetAll() Count is " + list.Count;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "你的应用程序说明页。";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "你的联系方式页。";

            return View();
        }
    }
}
