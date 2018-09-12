using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FirstApp.Models;

namespace FirstApp.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public DateTime? ExpenseDate { get; set; }
        public CategoryType CategoryType { get; set; }
        public byte CategoryTypeId { get; set; }



    }
}