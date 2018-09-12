using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Expense.Models;

namespace Expense.ViewModels
{
    public class ItemFormViewModel
    {
        public IEnumerable<CategoryType> CategoryTypes { get; set; }
        public Item Item { get; set; }
        public string Title
        {
            get
            {
                if (Item != null && Item.Id != 0)
                    return "Edit Item";
                return "New Item";
            }
        }
    }
}