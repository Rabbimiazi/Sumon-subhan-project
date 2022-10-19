using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resturant.Models
{
    public class ViewModel
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
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public int DishId { get; set; }
        public int OrderQuantity { get; set; }
        public int TotalPrice { get; set; }
    }
}