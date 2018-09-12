using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FirstApp.Models;

namespace FirstApp.ViewModels
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}