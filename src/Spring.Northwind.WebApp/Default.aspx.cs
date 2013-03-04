using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spring.Northwind.Dao;
using Spring.Northwind.Domain;
namespace Spring.Northwind.WebApp
{
    public partial class _Default : Page
    {
         private ICustomerDao customerDao;
        public ICustomerDao CustomerDao
        {
            set { this.customerDao = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           IList<Customer> list=this.customerDao.GetAll();

            Response.Write("spring.net IOC 测试 customerDao.GetAll() Count is " + list.Count);
        }
       
    }
}