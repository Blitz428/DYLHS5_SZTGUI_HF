using DYLHS5_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYLHS5_SZTGUI_2021222.WpfClient
{
    class OrderWindowViewModel
    {
        public RestCollection<Order> Orders { get; set; }
        public OrderWindowViewModel()
        {
            Orders = new RestCollection<Order>("http://localhost:27588/", "order");
        }
    }
}
