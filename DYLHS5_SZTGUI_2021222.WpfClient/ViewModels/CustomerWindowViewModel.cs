using DYLHS5_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYLHS5_SZTGUI_2021222.WpfClient
{
    class CustomerWindowViewModel
    {
        public RestCollection<Customer> Customers { get; set; }
        public CustomerWindowViewModel()
        {
            Customers = new RestCollection<Customer>("http://localhost:27588/", "customer");
        }
    }
}
