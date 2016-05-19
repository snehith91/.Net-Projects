using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerApplication.Models
{
    public class Orders
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public int OrderTotal { get; set; }
        public DateTime OrderDate { get; set; }

    }
}