using EventsApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using EventsApplication.Models;

namespace EventsApplication.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerController()
        {
            _dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }
        // GET: ParticipantController
        public ActionResult Index()
        {
            var customers = _dbContext.Customers.Include(c => c.Event).ToList();
            return View(customers);
        }



    }
}