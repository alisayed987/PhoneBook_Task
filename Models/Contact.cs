using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;


namespace PhoneBook.Models
{
    public class ContactContext : DbContext
    {
        public DbSet<Contact> Contact { get; set; }
    }
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        [StringLength(15)]
        public string Name { get; set; }
        [Required]
        [StringLength(11)]
        public string Phone { get; set; }

    }
}