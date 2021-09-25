using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneBook.Models;

namespace PhoneBook.Controllers
{
    public class ContactController : Controller
    {


        private ContactContext _context;
        public ContactController()
        {
            _context = new ContactContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(Contact conta)
        {
            if (conta.Id == 0) {
                _context.Contact.Add(conta);
                _context.SaveChanges();
                return RedirectToAction("Create");

            } else
            {
                var contact = _context.Contact.SingleOrDefault(c => c.Id == conta.Id);
                contact.Name = conta.Name;
                contact.Phone = conta.Phone;
                _context.SaveChanges();

                return RedirectToAction("GetContact");

            }

        }
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetContact(Contact check)
        {
            if(check.Name == null)
            {
            List<Contact> n = _context.Contact.ToList();
            return View(n);
            }
            else
            {
                return View(check);
            }

            }

        public ActionResult Edit(int? id)
        {
            var contact = _context.Contact.SingleOrDefault(c => c.Id == id);
            if (contact == null) { return HttpNotFound(); }
            Contact conta = new Contact
            {
                Id = contact.Id,
                Name = contact.Name,
                Phone = contact.Phone
            };
            return View("Create", conta);
        }


        public ActionResult Delete(int? id)
        {
            var contact = _context.Contact.SingleOrDefault(c => c.Id == id);
            if (contact == null) { return HttpNotFound(); }
            _context.Contact.Remove(contact);
            _context.SaveChanges();
            return RedirectToAction("GetContact");
        }

        public ActionResult Find(string st, string search)
        {
            if (search == "Name")
            {
                var query = _context.Contact.Where(b=> b.Name.Contains(st));
                return View("GetContact",query);
        }
            else{
                var query = _context.Contact.Where(b => b.Phone.Contains(st));
                return View("GetContact", query);
            }    
    }
        // For Testing
        private Contact Funct()
        {
            Contact con = new Contact() { Id = 2, Name = "Ali", Phone = "02222" };
            
            return con;
        }

    }
}