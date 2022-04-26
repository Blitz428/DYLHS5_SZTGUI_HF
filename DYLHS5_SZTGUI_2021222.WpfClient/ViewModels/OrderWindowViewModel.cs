using DYLHS5_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DYLHS5_SZTGUI_2021222.WpfClient
{
    class OrderWindowViewModel
    {
        public RestCollection<Order> Orders { get; set; }
        public OrderWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Orders = new RestCollection<Order>("http://localhost:27588/", "order");
            }
            
        }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }

        }
    }
}
