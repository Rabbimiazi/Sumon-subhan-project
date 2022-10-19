using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Resturant.Models
{
    public class DbModel:DbContext
    {
        public DbSet<Reserve> reserves { get; set; }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<Menue> menues { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Mail> mails { get; set; }
    }

    public class Reserve
    {
        public int ReserveId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string Person { get; set; }
        public bool Confirmed { get; set; }
        public bool Served { get; set; }
        public string AdminPerson { get; set; }
    }

    public class Contact
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }

    public class Menue
    {
        public int MenueId { get; set; }
        public string MenueName { get; set; }
        public string DishTitle { get; set; }
        public decimal Price { get; set; }
        public string ImsgeUrl { get; set; }
        public bool IsActive { get; set; }
        public string Materials { get; set; }
        public string Materials1 { get; set; } 
        public string Materials2 { get; set; }
        public string Materials3 { get; set; }
        public string AdminPerson { get; set; }

        [NotMapped]
        public HttpPostedFileBase FileImage { get; set; }

    }

    public class Order
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public int DishId { get; set; }
        public int OrderQuantity { get; set; }
        public int TotalPrice { get; set; }
        public string AdminPerson { get; set; }
        public bool Confirmed { get; set; }
        public bool Served { get; set; }
    }

    public class Mail
    {
        
        public int MailId { get; set; }
        public string TO { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Name { get; set; }
        public string ProfileName { get; set; }
        public string CategoryType { get; set; }
      
     

       

    }
}