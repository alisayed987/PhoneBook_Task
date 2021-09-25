using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhoneBook.Models;

namespace PhoneBook.ViewModels
{
    public class NewContactViewModel
    {
        public IEnumerable<Contact> MyContacts { get; set; }
        public Contact Contact { get; set; }
    }
}